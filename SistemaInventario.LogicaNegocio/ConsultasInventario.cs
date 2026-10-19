using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// consultas LINQ que usan los filtros y la pestana del resumen
public class ConsultasInventario
{
    private readonly IRepositorio<Producto> productos;
    private readonly IRepositorio<Categoria> categorias;
    private readonly IRepositorio<Suplidor> suplidores;
    private readonly SesionUsuario sesion;
    // recibe por constructor lo que necesita como los otros servicios
    /// <summary>
    /// recibe los datos necesarios para las consultas LINQ del inventario
    /// </summary>
    /// <param name="productos">dato que necesita la operacion</param>
    /// <param name="categorias">dato que necesita la operacion</param>
    /// <param name="suplidores">dato que necesita la operacion</param>
    /// <param name="sesion">dato que necesita la operacion</param>
    public ConsultasInventario(IRepositorio<Producto> productos, IRepositorio<Categoria> categorias, IRepositorio<Suplidor> suplidores, SesionUsuario sesion)
    { this.productos = productos; this.categorias = categorias; this.suplidores = suplidores; this.sesion = sesion; }
    // consulta LINQ 1: junta los productos con sus categorias y suplidores activos
    /// <summary>
    /// obtiene productos con el nombre de su categoria y su suplidor
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<ProductoListado> ListadoProductos()
    {
        sesion.ExigirAcceso();
        return (from p in productos.Listar()
                join c in categorias.Listar() on p.CategoriaId equals c.Id
                join s in suplidores.Listar() on p.SuplidorId equals s.Id
                orderby p.Nombre
                select new ProductoListado { Id = p.Id, Nombre = p.Nombre, PrecioUnitario = p.PrecioUnitario,
                    CategoriaId = c.Id, Categoria = c.Nombre, SuplidorId = s.Id, Suplidor = s.NombreEmpresa,
                    Foto = p.Foto, FechaCreacion = p.FechaCreacion, FechaModificacion = p.FechaModificacion }).ToList();
    }
    // consulta LINQ 2: filtra por texto, categoria, suplidor y precios al mismo tiempo
    /// <summary>
    /// aplica los filtros de texto, categoria, suplidor y precios
    /// </summary>
    /// <param name="lista">lista de productos sobre la que se aplican filtros</param>
    /// <param name="texto">texto usado para buscar o convertir datos</param>
    /// <param name="categoriaId">identificador de la categoria usada para filtrar</param>
    /// <param name="suplidorId">identificador del suplidor usado para filtrar</param>
    /// <param name="minimo">valor minimo permitido</param>
    /// <param name="maximo">valor maximo permitido</param>
    /// <returns>resultado de la operacion</returns>
    public List<ProductoListado> FiltrarProductos(IEnumerable<ProductoListado> lista, string texto, int? categoriaId, int? suplidorId, decimal? minimo, decimal? maximo)
    {
        sesion.ExigirAcceso();
        if ((minimo.HasValue && minimo < 0) || (maximo.HasValue && maximo < 0) || (minimo.HasValue && maximo.HasValue && minimo > maximo))
            throw new ValidacionException("RangoPrecios", "El rango debe ser positivo y el minimo no puede superar al maximo.");
        string criterio = (texto ?? "").Trim();
        return lista.Where(p => p.Nombre.IndexOf(criterio, StringComparison.OrdinalIgnoreCase) >= 0)
            .Where(p => !categoriaId.HasValue || p.CategoriaId == categoriaId.Value)
            .Where(p => !suplidorId.HasValue || p.SuplidorId == suplidorId.Value)
            .Where(p => !minimo.HasValue || p.PrecioUnitario >= minimo.Value)
            .Where(p => !maximo.HasValue || p.PrecioUnitario <= maximo.Value)
            .OrderBy(p => p.Nombre).ThenBy(p => p.PrecioUnitario).ToList();
    }
    // consulta LINQ 3: agrupa por categoria y muestra tambien las que no tienen productos
    /// <summary>
    /// cuenta los productos activos agrupados por categoria
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<ResumenCategoria> ConteoPorCategoria()
    {
        sesion.ExigirAcceso();
        return categorias.Listar().GroupJoin(productos.Listar(), c => c.Id, p => p.CategoriaId,
            (c, grupo) => new ResumenCategoria { Categoria = c.Nombre, CantidadProductos = grupo.Count() })
            .OrderByDescending(x => x.CantidadProductos).ThenBy(x => x.Categoria).ToList();
    }
    // consulta LINQ 4: agrupa y junta los datos para sacar los cinco suplidores con mas productos
    /// <summary>
    /// obtiene los cinco suplidores con mayor cantidad de productos
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<ResumenSuplidor> TopSuplidores()
    {
        sesion.ExigirAcceso();
        return productos.Listar().GroupBy(p => p.SuplidorId)
            .Join(suplidores.Listar(), grupo => grupo.Key, s => s.Id,
                (grupo, s) => new ResumenSuplidor { Suplidor = s.NombreEmpresa, CantidadProductos = grupo.Count() })
            .OrderByDescending(x => x.CantidadProductos).ThenBy(x => x.Suplidor).Take(5).ToList();
    }
    // consulta LINQ 5: saca el promedio y los precios menor y mayor de cada categoria
    /// <summary>
    /// calcula los precios minimo, maximo y promedio por categoria
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<EstadisticaPrecios> PreciosPorCategoria()
    {
        sesion.ExigirAcceso();
        return productos.Listar().GroupBy(p => p.CategoriaId)
            .Join(categorias.Listar(), grupo => grupo.Key, c => c.Id,
                (grupo, c) => new EstadisticaPrecios { Categoria = c.Nombre, CantidadProductos = grupo.Count(),
                    PrecioPromedio = decimal.Round(grupo.Average(p => p.PrecioUnitario), 2),
                    PrecioMinimo = grupo.Min(p => p.PrecioUnitario), PrecioMaximo = grupo.Max(p => p.PrecioUnitario) })
            .OrderBy(x => x.Categoria).ToList();
    }
    // consulta LINQ 6: muestra los mas caros y si empatan los ordena por nombre
    /// <summary>
    /// muestra los cinco productos con el precio mas alto
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<ProductoListado> ProductosMasCaros()
    { return ListadoProductos().OrderByDescending(p => p.PrecioUnitario).ThenBy(p => p.Nombre).Take(5).ToList(); }
}
}
