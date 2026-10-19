using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;
using System.Security.Cryptography;
namespace SistemaInventario.LogicaNegocio
{
// compara las claves sin guardar la contrasena tal cual en la base
public static class SeguridadClave
{
    public const int Iteraciones = 100000;
    // crea una sal al azar para que cada cuenta tenga la suya
    /// <summary>
    /// genera una sal aleatoria para proteger las contrasenas
    /// </summary>
    /// <returns>texto calculado por la operacion</returns>
    public static string CrearSal()
    {
        byte[] sal = new byte[16];
        using (RandomNumberGenerator azar = RandomNumberGenerator.Create()) azar.GetBytes(sal);
        return Convert.ToBase64String(sal);
    }
    // saca el hash de la clave usando PBKDF2 y la sal de esa cuenta
    /// <summary>
    /// calcula el hash de la contrasena usando su sal
    /// </summary>
    /// <param name="clave">contrasena escrita por el usuario</param>
    /// <param name="sal">sal usada para calcular la contrasena</param>
    /// <returns>texto calculado por la operacion</returns>
    public static string Calcular(string clave, string sal)
    {
        using (Rfc2898DeriveBytes calculo = new Rfc2898DeriveBytes(clave, Convert.FromBase64String(sal), Iteraciones, HashAlgorithmName.SHA256))
            return Convert.ToBase64String(calculo.GetBytes(32));
    }
    // compara todos los bytes aunque encuentre uno diferente antes de terminar
    /// <summary>
    /// comprueba si la contrasena coincide con el hash almacenado
    /// </summary>
    /// <param name="clave">contrasena escrita por el usuario</param>
    /// <param name="sal">sal usada para calcular la contrasena</param>
    /// <param name="hash">hash guardado para comprobar la contrasena</param>
    /// <returns>verdadero si pasa la comprobacion; falso en caso contrario</returns>
    public static bool Coincide(string clave, string sal, string hash)
    {
        byte[] actual = Convert.FromBase64String(Calcular(clave, sal));
        byte[] esperado = Convert.FromBase64String(hash);
        if (actual.Length != esperado.Length) return false;
        int diferencia = 0;
        for (int i = 0; i < actual.Length; i++) diferencia |= actual[i] ^ esperado[i];
        return diferencia == 0;
    }
}
}
