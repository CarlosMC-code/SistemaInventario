using System;
using System.Collections.Generic;
namespace SistemaInventario.Entidades
{
// estas son las operaciones que usa cualquier repositorio
public interface IRepositorio<T> where T : EntidadBase
{
    // trae los activos o todos los registros si se le pide
    /// <summary>
    /// obtiene los registros activos o todos si se solicita
    /// </summary>
    /// <param name="incluirInactivos">indica si se incluyen los registros inactivos</param>
    /// <returns>resultado de la operacion</returns>
    List<T> Listar(bool incluirInactivos = false);
    // busca por id y devuelve null si no lo encuentra
    /// <summary>
    /// busca un registro por su identificador
    /// </summary>
    /// <param name="id">identificador del registro</param>
    /// <returns>resultado de la operacion</returns>
    T Obtener(int id);
    // guarda el registro nuevo y devuelve su id
    /// <summary>
    /// guarda un registro nuevo y devuelve su identificador
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    /// <returns>identificador o valor calculado por la operacion</returns>
    int Agregar(T entidad);
    // guarda los cambios del registro
    /// <summary>
    /// guarda los cambios hechos a un registro existente
    /// </summary>
    /// <param name="entidad">registro que se va a revisar o guardar</param>
    void Actualizar(T entidad);
    // lo pone como inactivo para mandarlo a la papelera
    /// <summary>
    /// marca un registro como inactivo sin borrarlo fisicamente
    /// </summary>
    /// <param name="id">identificador del registro</param>
    void Eliminar(int id);
    // activa otra vez el registro que estaba en la papelera
    /// <summary>
    /// vuelve a activar un registro que estaba en la papelera
    /// </summary>
    /// <param name="id">identificador del registro</param>
    void Restaurar(int id);
}
}
