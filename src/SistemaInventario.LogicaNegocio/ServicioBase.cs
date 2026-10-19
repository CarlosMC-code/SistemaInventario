using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// aqui va lo que se repite al guardar, eliminar y restaurar
public abstract class ServicioBase<T> where T : EntidadBase
{
    protected readonly IRepositorio<T> repositorio;
    protected readonly SesionUsuario sesion;
    // recibe por constructor lo que va a necesitar
    /// <summary>
    /// recibe un repositorio y la sesion que compartiran sus operaciones
    /// </summary>
    /// <param name="repositorio">dato que necesita la operacion</param>
    /// <param name="sesion">dato que necesita la operacion</param>
    protected ServicioBase(IRepositorio<T> repositorio, SesionUsuario sesion) { this.repositorio = repositorio; this.sesion = sesion; }
    // trae los registros que siguen activos
    /// <summary>
    /// obtiene los registros activos o todos si se solicita
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<T> Listar() { sesion.ExigirAcceso(); return repositorio.Listar(); }
    // trae lo de la papelera despues de revisar que sea administrador
    /// <summary>
    /// trae los registros inactivos que se encuentran en la papelera
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public List<T> ListarEliminados() { sesion.ExigirAcceso(true); return repositorio.Listar(true).Where(x => !x.Activo).OrderByDescending(x => x.FechaModificacion).ToList(); }
    // busca un registro activo para verlo o editarlo
    /// <summary>
    /// busca un registro por su identificador
    /// </summary>
    /// <param name="id">identificador del registro</param>
    /// <returns>resultado de la operacion</returns>
    public T Obtener(int id)
    {
        sesion.ExigirAcceso(); T entidad = repositorio.Obtener(id);
        if (entidad == null || !entidad.Activo) throw new ValidacionException("Id", "El registro no existe o esta en la papelera.");
        return entidad;
    }
    protected virtual bool SoloAdministradorParaGuardar { get { return true; } }
    /// <summary>
    /// comprueba las reglas de negocio de la entidad
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected abstract void Validar(T entidad);
    /// <summary>
    /// comprueba que la entidad se puede enviar a la papelera
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected virtual void ValidarEliminacion(T entidad) { }
    /// <summary>
    /// comprueba que la entidad se puede restaurar sin romper relaciones
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    protected virtual void ValidarRestauracion(T entidad) { }
    // revisa los datos y guarda el registro sea nuevo o ya exista
    /// <summary>
    /// valida y guarda el registro nuevo o los cambios del existente
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    /// <returns>identificador o valor calculado por la operacion</returns>
    public virtual int Guardar(T entidad)
    {
        sesion.ExigirAcceso(SoloAdministradorParaGuardar);
        // revisa los permisos aqui tambien por si se llama al servicio sin usar el boton
        if (entidad == null) throw new ArgumentNullException(nameof(entidad));
        if (entidad.Id != 0) Obtener(entidad.Id);
        Validar(entidad);
        // si el id esta en cero es porque todavia no se ha guardado en la base
        if (entidad.Id == 0) return repositorio.Agregar(entidad);
        repositorio.Actualizar(entidad); return entidad.Id;
    }
    // deja que el administrador lo mande a la papelera si sus relaciones lo permiten
    /// <summary>
    /// marca un registro como inactivo sin borrarlo fisicamente
    /// </summary>
    /// <param name="id">identificador del registro</param>
    public void Eliminar(int id)
    { sesion.ExigirAcceso(true); T entidad = Obtener(id); ValidarEliminacion(entidad); repositorio.Eliminar(id); }
    // restaura el registro de la papelera si sus datos siguen estando bien
    /// <summary>
    /// vuelve a activar un registro que estaba en la papelera
    /// </summary>
    /// <param name="id">identificador del registro</param>
    public void Restaurar(int id)
    {
        sesion.ExigirAcceso(true); T entidad = repositorio.Obtener(id);
        if (entidad == null || entidad.Activo) throw new ValidacionException("Id", "El registro no esta en la papelera.");
        ValidarRestauracion(entidad); repositorio.Restaurar(id);
    }
}
}
