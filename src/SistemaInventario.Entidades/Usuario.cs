using System;

namespace SistemaInventario.Entidades
{
// datos de la cuenta y su clave guardada como hash con sal
public class Usuario : EntidadBase
{
    public string NombreUsuario { get; set; } = "";
    public string NombreCompleto { get; set; } = "";
    public string Rol { get; set; } = "Usuario";
    public string ClaveHash { get; set; } = "";
    public string Sal { get; set; } = "";
}
}
