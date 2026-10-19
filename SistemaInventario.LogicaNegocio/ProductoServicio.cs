using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// aqui revisa el producto antes de mandarlo a la base de datos
public class ProductoServicio : ServicioBase<Producto>
{
    private readonly IRepositorio<Categoria> categorias;
    private readonly IRepositorio<Suplidor> suplidores;
    protected override bool SoloAdministradorParaGuardar { get { return false; } }
    // recibe los tres repositorios y la sesion por constructor
    /// <summary>
    /// recibe los repositorios y la sesion para administrar productos
    /// </summary>
    /// <param name="productos">dato que necesita la operacion</param>
    /// <param name="categorias">dato que necesita la operacion</param>
    /// <param name="suplidores">dato que necesita la operacion</param>
    /// <param name="sesion">dato que necesita la operacion</param>
    public ProductoServicio(IRepositorio<Producto> productos, IRepositorio<Categoria> categorias, IRepositorio<Suplidor> suplidores, SesionUsuario sesion) : base(productos, sesion)
    { this.categorias = categorias; this.suplidores = suplidores; }
    // recibe el precio que se escribio y revisa si se puede guardar
    /// <summary>
    /// convierte y valida el precio antes de guardar el producto
    /// </summary>
    /// <param name="producto">dato que necesita la operacion</param>
    /// <param name="precioTexto">dato que necesita la operacion</param>
    /// <returns>identificador o valor calculado por la operacion</returns>
    public int GuardarConPrecio(Producto producto, string precioTexto)
    {
        sesion.ExigirAcceso(); producto.PrecioUnitario = Validador.LeerPrecio(precioTexto); return Guardar(producto);
    }
    // carga la foto aqui para que el formulario no tenga que revisar archivos
    /// <summary>
    /// lee y valida una foto para asociarla a la entidad
    /// </summary>
    /// <param name="producto">dato que necesita la operacion</param>
    /// <param name="ruta">ruta del archivo que se va a cargar</param>
    public void CargarFoto(Producto producto, string ruta)
    {
        sesion.ExigirAcceso();
        string nombre;
        byte[] contenido = ValidadorFotos.LeerContenido(ruta, out nombre, "Foto");
        producto.FotoNombre = nombre;
        producto.Foto = contenido;
    }
    /// <summary>
    /// comprueba las reglas de negocio de la entidad
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void Validar(Producto entidad)
    {
        List<ErrorValidacion> errores = new List<ErrorValidacion>();
        entidad.Nombre = Validador.Texto(errores, "Nombre", entidad.Nombre, 3, 150);
        Validador.Precio(errores, entidad.PrecioUnitario);
        if (entidad.Foto != null || !string.IsNullOrEmpty(entidad.FotoNombre))
            ValidadorFotos.ValidarContenido(entidad.FotoNombre, entidad.Foto, errores, "Foto");
        // revisa tambien que la categoria y el suplidor sigan activos
        Categoria categoria = categorias.Obtener(entidad.CategoriaId);
        Suplidor suplidor = suplidores.Obtener(entidad.SuplidorId);
        if (categoria == null || !categoria.Activo) errores.Add(new ErrorValidacion("CategoriaId", "Selecciona una categoria activa."));
        if (suplidor == null || !suplidor.Activo) errores.Add(new ErrorValidacion("SuplidorId", "Selecciona un suplidor activo."));
        Validador.LanzarSiHay(errores);
    }
    /// <summary>
    /// comprueba que la entidad se puede restaurar sin romper relaciones
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void ValidarRestauracion(Producto entidad) { Validar(entidad); }
}
}
