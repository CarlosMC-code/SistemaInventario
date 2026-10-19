using System;

namespace SistemaInventario.Entidades
{
// busca las cuentas para poder iniciar sesion
public interface IUsuarioRepositorio
{
    // busca la cuenta por su nombre y devuelve null si no existe
    /// <summary>
    /// busca una cuenta por su nombre de usuario
    /// </summary>
    /// <param name="nombreUsuario">nombre de usuario que se busca</param>
    /// <returns>resultado de la operacion</returns>
    Usuario BuscarPorNombre(string nombreUsuario);
}
}
