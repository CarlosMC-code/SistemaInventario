using System;

namespace SistemaInventario.Entidades
{
// datos que tienen en comun los registros del sistema
public abstract class EntidadBase
{
    public int Id { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }

    // hace una copia para no cambiar el registro original antes de guardar
    /// <summary>
    /// crea una copia de la entidad sin modificar el original
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public virtual EntidadBase Copiar() { return (EntidadBase)MemberwiseClone(); }
}
}
