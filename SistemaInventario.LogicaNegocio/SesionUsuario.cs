using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// guarda quien entro para poder revisar sus permisos
public class SesionUsuario
{
    public Usuario UsuarioActual { get; private set; }
    public bool HaySesion { get { return UsuarioActual != null; } }
    public bool EsAdministrador { get { return HaySesion && UsuarioActual.Rol == "Administrador"; } }
    internal void Iniciar(Usuario usuario) { UsuarioActual = usuario; }
    // quita la cuenta cuando se cierra la sesion
    /// <summary>
    /// cierra la sesion del usuario actual
    /// </summary>
    public void Cerrar() { UsuarioActual = null; }
    // revisa la sesion y si hace falta tambien pide que sea administrador
    /// <summary>
    /// comprueba que hay una sesion y que tiene el permiso necesario
    /// </summary>
    /// <param name="administrador">indica si se necesita permiso de administrador</param>
    public void ExigirAcceso(bool administrador = false)
    {
        if (!HaySesion) throw new PermisoException("Primero tienes que iniciar sesion.");
        if (administrador && !EsAdministrador) throw new PermisoException("Solo el administrador puede realizar esta accion.");
    }
}
}
