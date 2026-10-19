using System;

namespace SistemaInventario.Entidades
{
// foto que pertenece a una categoria
public class FotoCategoria : EntidadBase
{
    public int CategoriaId { get; set; }
    public string NombreArchivo { get; set; } = "";
    public byte[] Contenido { get; set; } = new byte[0];

    // copia los bytes para no estar editando la misma imagen en dos lugares
    /// <summary>
    /// crea una copia de la entidad sin modificar el original
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public override EntidadBase Copiar()
    {
        FotoCategoria copia = (FotoCategoria)base.Copiar();
        copia.Contenido = (byte[])Contenido.Clone();
        return copia;
    }
}
}
