using System;
using System.Collections.Generic;
using System.Linq;
namespace SistemaInventario.Entidades
{
// datos de la categoria y sus fotos que se guardan en la base de datos
public class Categoria : EntidadBase
{
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public int CantidadFotos { get; set; }
    /// <summary>
    /// guarda las fotos asociadas con la categoria
    /// </summary>
    public List<FotoCategoria> Fotos { get; set; } = new List<FotoCategoria>();

    // copia tambien las fotos para que al editar no cambie la lista original
    /// <summary>
    /// crea una copia de la entidad sin modificar el original
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public override EntidadBase Copiar()
    {
        Categoria copia = (Categoria)base.Copiar();
        copia.Fotos = Fotos.Select(f => (FotoCategoria)f.Copiar()).ToList();
        return copia;
    }
}
}
