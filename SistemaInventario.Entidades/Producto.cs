using System;

namespace SistemaInventario.Entidades
{
// datos del producto con su categoria y su suplidor
public class Producto : EntidadBase
{
    public string Nombre { get; set; } = "";
    public decimal PrecioUnitario { get; set; }
    public int CategoriaId { get; set; }
    public int SuplidorId { get; set; }
    public string FotoNombre { get; set; } = "";
    public byte[] Foto { get; set; }

    // copia tambien la foto para que al cancelar no cambie la original
    /// <summary>
    /// crea una copia de la entidad sin modificar el original
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public override EntidadBase Copiar()
    {
        Producto copia = (Producto)base.Copiar();
        copia.Foto = Foto == null ? null : (byte[])Foto.Clone();
        return copia;
    }
}
}
