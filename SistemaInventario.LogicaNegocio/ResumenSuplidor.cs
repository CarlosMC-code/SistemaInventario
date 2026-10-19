using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// datos que devuelve una consulta LINQ para mostrarlos en la tabla
public class ResumenSuplidor
{
    public string Suplidor { get; set; }
    public int CantidadProductos { get; set; }
}
}
