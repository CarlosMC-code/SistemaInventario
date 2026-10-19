using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// datos que devuelve una consulta LINQ para mostrarlos en la tabla
public class EstadisticaPrecios
{
    public string Categoria { get; set; }
    public int CantidadProductos { get; set; }
    public decimal PrecioPromedio { get; set; }
    public decimal PrecioMinimo { get; set; }
    public decimal PrecioMaximo { get; set; }
}
}
