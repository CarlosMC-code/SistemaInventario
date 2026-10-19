using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// revisa la categoria, sus fotos y los productos que tiene
public class CategoriaServicio : ServicioBase<Categoria>
{
    private readonly IRepositorio<Producto> productos;
    // recibe los repositorios y la sesion que va a usar
    /// <summary>
    /// recibe los repositorios y la sesion para administrar categorias
    /// </summary>
    /// <param name="categorias">dato que necesita la operacion</param>
    /// <param name="productos">dato que necesita la operacion</param>
    /// <param name="sesion">dato que necesita la operacion</param>
    public CategoriaServicio(IRepositorio<Categoria> categorias, IRepositorio<Producto> productos, SesionUsuario sesion) : base(categorias, sesion) { this.productos = productos; }
    /// <summary>
    /// comprueba las reglas de negocio de la entidad
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void Validar(Categoria entidad)
    {
        List<ErrorValidacion> errores = new List<ErrorValidacion>();
        entidad.Nombre = Validador.Texto(errores, "Nombre", entidad.Nombre, 3, 100);
        entidad.Descripcion = Validador.Texto(errores, "Descripcion", entidad.Descripcion, 1, 500);
        // cuenta tambien lo de la papelera para que despues se pueda restaurar sin repetir nombres
        if (repositorio.Listar(true).Any(x => x.Id != entidad.Id && string.Equals(x.Nombre, entidad.Nombre, StringComparison.OrdinalIgnoreCase)))
            errores.Add(new ErrorValidacion("Nombre", "Ya existe una categoria con ese nombre, incluso en la papelera."));
        if (entidad.Fotos == null) entidad.Fotos = new List<FotoCategoria>();
        if (entidad.Fotos.Count > 5) errores.Add(new ErrorValidacion("Fotos", "Una categoria puede tener de 0 a 5 fotos."));
        foreach (FotoCategoria foto in entidad.Fotos) ValidadorFotos.Validar(foto, errores);
        entidad.CantidadFotos = entidad.Fotos.Count;
        Validador.LanzarSiHay(errores);
    }
    /// <summary>
    /// comprueba que la entidad se puede enviar a la papelera
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void ValidarEliminacion(Categoria entidad)
    {
        // si tiene productos activos primero hay que moverlos o mandarlos a la papelera
        if (productos.Listar().Any(p => p.CategoriaId == entidad.Id))
            throw new ValidacionException("Id", "No puedes eliminar la categoria porque tiene productos activos asociados.");
    }
    // revisa y carga la foto que eligio el usuario
    /// <summary>
    /// lee y valida una foto para asociarla a la entidad
    /// </summary>
    /// <param name="ruta">ruta del archivo que se va a cargar</param>
    /// <param name="cantidadActual">cantidad de fotos que ya tiene la categoria</param>
    /// <returns>resultado de la operacion</returns>
    public FotoCategoria CargarFoto(string ruta, int cantidadActual = 0)
    {
        sesion.ExigirAcceso(true);
        if (cantidadActual >= 5) throw new ValidacionException("Fotos", "Solo se permiten hasta cinco fotos por categoria.");
        return ValidadorFotos.LeerArchivo(ruta);
    }
    // busca en la lista que ya se trajo de SQL Server
    /// <summary>
    /// filtra los elementos de acuerdo con el texto escrito
    /// </summary>
    /// <param name="categorias">dato que necesita la operacion</param>
    /// <param name="texto">texto usado para buscar o convertir datos</param>
    /// <returns>resultado de la operacion</returns>
    public List<Categoria> Buscar(IEnumerable<Categoria> categorias, string texto)
    { sesion.ExigirAcceso(); return BusquedaGenerica.Filtrar(categorias, texto, c => c.Nombre + " " + c.Descripcion); }
}
}
