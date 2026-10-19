using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// datos que devuelve una consulta LINQ para mostrarlos en la tabla
public class ProductoListado
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int CategoriaId { get; set; }
    public string Categoria { get; set; }
    public int SuplidorId { get; set; }
    public string Suplidor { get; set; }
    public byte[] Foto { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}
}
