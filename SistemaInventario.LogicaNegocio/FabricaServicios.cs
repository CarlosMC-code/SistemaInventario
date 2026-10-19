using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;
using SistemaInventario.AccesoDatos;
namespace SistemaInventario.LogicaNegocio
{
// aqui se arman los servicios con sus repositorios de SQL Server
public static class FabricaServicios
{
    // prepara lo que necesita el programa para usar la base de datos
    /// <summary>
    /// crea los servicios y conecta los repositorios de SQL Server
    /// </summary>
    /// <returns>resultado de la operacion</returns>
    public static ServiciosAplicacion Crear()
    {
        // usa siempre SQL Server y los ejemplos se cargan ejecutando datos.sql
        IConexionBD conexion = ConexionBD.Instancia;
        return new ServiciosAplicacion(new CategoriaRepositorio(conexion), new SuplidorRepositorio(conexion),
            new ProductoRepositorio(conexion), new UsuarioRepositorio(conexion));
    }
}
}
