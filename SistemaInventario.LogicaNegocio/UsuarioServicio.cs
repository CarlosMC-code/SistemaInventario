using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;

namespace SistemaInventario.LogicaNegocio
{
// revisa el usuario y la clave antes de dejarlo entrar al programa
public class UsuarioServicio
{
    private readonly IUsuarioRepositorio usuarios;
    private readonly SesionUsuario sesion;
    // recibe repositorio y sesion por constructor
    /// <summary>
    /// recibe el acceso a usuarios y la sesion para iniciar sesion
    /// </summary>
    /// <param name="usuarios">dato que necesita la operacion</param>
    /// <param name="sesion">dato que necesita la operacion</param>
    public UsuarioServicio(IUsuarioRepositorio usuarios, SesionUsuario sesion) { this.usuarios = usuarios; this.sesion = sesion; }
    // deja entrar si la cuenta esta activa y la clave coincide
    /// <summary>
    /// comprueba el usuario y la contrasena e inicia la sesion
    /// </summary>
    /// <param name="nombreUsuario">nombre de usuario que se busca</param>
    /// <param name="clave">contrasena escrita por el usuario</param>
    public void Autenticar(string nombreUsuario, string clave)
    {
        sesion.Cerrar();
        List<ErrorValidacion> errores = new List<ErrorValidacion>();
        if (string.IsNullOrWhiteSpace(nombreUsuario)) errores.Add(new ErrorValidacion("NombreUsuario", "Escribe el usuario."));
        if (string.IsNullOrEmpty(clave)) errores.Add(new ErrorValidacion("Clave", "Escribe la clave."));
        if (errores.Count > 0) throw new ValidacionException(errores);
        if (nombreUsuario.Trim().Length > 50 || clave.Length > 200) throw new ValidacionException("Clave", "Usuario o clave incorrectos.");
        Usuario usuario = usuarios.BuscarPorNombre(nombreUsuario.Trim());
        // muestra el mismo mensaje si falla el usuario o la clave para no decir cual fue
        if (usuario == null || !usuario.Activo || !SeguridadClave.Coincide(clave, usuario.Sal, usuario.ClaveHash))
            throw new ValidacionException("Clave", "Usuario o clave incorrectos.");
        if (usuario.Rol != "Administrador" && usuario.Rol != "Usuario") throw new PermisoException("La cuenta no tiene un rol valido.");
        sesion.Iniciar(usuario);
    }
}
}
