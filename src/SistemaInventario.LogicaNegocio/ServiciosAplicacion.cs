using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// junta los servicios para pasarselos a los formularios
public class ServiciosAplicacion
{
    public SesionUsuario Sesion { get; private set; }
    public UsuarioServicio Usuarios { get; private set; }
    public CategoriaServicio Categorias { get; private set; }
    public SuplidorServicio Suplidores { get; private set; }
    public ProductoServicio Productos { get; private set; }
    public ConsultasInventario Consultas { get; private set; }
    // recibe los repositorios y se los pasa a cada servicio
    /// <summary>
    /// organiza los servicios para que los formularios puedan utilizarlos
    /// </summary>
    /// <param name="categorias">dato que necesita la operacion</param>
    /// <param name="suplidores">dato que necesita la operacion</param>
    /// <param name="productos">dato que necesita la operacion</param>
    /// <param name="usuarios">dato que necesita la operacion</param>
    public ServiciosAplicacion(IRepositorio<Categoria> categorias, IRepositorio<Suplidor> suplidores,
        IRepositorio<Producto> productos, IUsuarioRepositorio usuarios)
    {
        // comparte la misma sesion para que todos revisen los mismos permisos
        Sesion = new SesionUsuario();
        Usuarios = new UsuarioServicio(usuarios, Sesion);
        Categorias = new CategoriaServicio(categorias, productos, Sesion);
        Suplidores = new SuplidorServicio(suplidores, productos, Sesion);
        Productos = new ProductoServicio(productos, categorias, suplidores, Sesion);
        Consultas = new ConsultasInventario(productos, categorias, suplidores, Sesion);
    }
}
}
