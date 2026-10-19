using System;

namespace SistemaInventario.Entidades
{
// datos de la empresa que vende los productos
public class Suplidor : EntidadBase
{
    public string NombreEmpresa { get; set; } = "";
    public string NombreContacto { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Correo { get; set; } = "";
    public string SitioWeb { get; set; } = "";
}
}
