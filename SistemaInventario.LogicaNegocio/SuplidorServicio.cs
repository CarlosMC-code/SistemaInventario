using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// revisa los datos del suplidor y que no se borre si tiene productos activos
public class SuplidorServicio : ServicioBase<Suplidor>
{
    private readonly IRepositorio<Producto> productos;
    // recibe repositorios y sesion por constructor
    /// <summary>
    /// recibe los repositorios y la sesion para administrar suplidores
    /// </summary>
    /// <param name="suplidores">dato que necesita la operacion</param>
    /// <param name="productos">dato que necesita la operacion</param>
    /// <param name="sesion">dato que necesita la operacion</param>
    public SuplidorServicio(IRepositorio<Suplidor> suplidores, IRepositorio<Producto> productos, SesionUsuario sesion) : base(suplidores, sesion) { this.productos = productos; }
    /// <summary>
    /// comprueba las reglas de negocio de la entidad
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void Validar(Suplidor entidad)
    {
        List<ErrorValidacion> errores = new List<ErrorValidacion>();
        entidad.NombreEmpresa = Validador.Texto(errores, "NombreEmpresa", entidad.NombreEmpresa, 3, 150);
        entidad.NombreContacto = Validador.Texto(errores, "NombreContacto", entidad.NombreContacto, 3, 100);
        entidad.Telefono = (entidad.Telefono ?? "").Trim(); entidad.Correo = (entidad.Correo ?? "").Trim(); entidad.SitioWeb = (entidad.SitioWeb ?? "").Trim();
        if (repositorio.Listar(true).Any(x => x.Id != entidad.Id && string.Equals(x.NombreEmpresa, entidad.NombreEmpresa, StringComparison.OrdinalIgnoreCase)))
            errores.Add(new ErrorValidacion("NombreEmpresa", "Ya existe una empresa con ese nombre, incluso en la papelera."));
        if (!Validador.TelefonoValido(entidad.Telefono)) errores.Add(new ErrorValidacion("Telefono", "Usa el formato 809-555-1234, 829-555-1234 o 849-555-1234."));
        if (entidad.Correo.Length > 150 || !Validador.CorreoValido(entidad.Correo)) errores.Add(new ErrorValidacion("Correo", "Escribe un correo valido de hasta 150 caracteres."));
        if (entidad.SitioWeb.Length > 250 || !Validador.WebValida(entidad.SitioWeb)) errores.Add(new ErrorValidacion("SitioWeb", "Escribe una URL http/https valida, o deja el campo vacio."));
        Validador.LanzarSiHay(errores);
    }
    /// <summary>
    /// comprueba que la entidad se puede enviar a la papelera
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected override void ValidarEliminacion(Suplidor entidad)
    {
        if (productos.Listar().Any(p => p.SuplidorId == entidad.Id))
            throw new ValidacionException("Id", "No puedes eliminar el suplidor porque tiene productos activos asociados.");
    }
    // busca por empresa, contacto, telefono o correo sin importar las mayusculas
    /// <summary>
    /// filtra los elementos de acuerdo con el texto escrito
    /// </summary>
    /// <param name="suplidores">dato que necesita la operacion</param>
    /// <param name="texto">texto usado para buscar o convertir datos</param>
    /// <returns>resultado de la operacion</returns>
    public List<Suplidor> Buscar(IEnumerable<Suplidor> suplidores, string texto)
    { sesion.ExigirAcceso(); return BusquedaGenerica.Filtrar(suplidores, texto, s => s.NombreEmpresa + " " + s.NombreContacto + " " + s.Telefono + " " + s.Correo); }
}
}
