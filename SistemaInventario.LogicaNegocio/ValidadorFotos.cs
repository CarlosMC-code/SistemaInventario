using System;
using System.Collections.Generic;
using System.Linq;
using SistemaInventario.Entidades;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
namespace SistemaInventario.LogicaNegocio
{
// revisa el formato, el contenido y el tamano de las fotos
public static class ValidadorFotos
{
    public const int MaximoBytes = 2 * 1024 * 1024;
    // usa la misma lectura para las fotos de categorias y productos
    /// <summary>
    /// lee y valida una foto desde el disco
    /// </summary>
    /// <param name="ruta">ruta del archivo que se va a cargar</param>
    /// <returns>resultado de la operacion</returns>
    public static FotoCategoria LeerArchivo(string ruta)
    {
        string nombre;
        byte[] contenido = LeerContenido(ruta, out nombre);
        return new FotoCategoria { NombreArchivo = nombre, Contenido = contenido };
    }
    // primero revisa el tamano para no cargar una foto demasiado grande
    /// <summary>
    /// carga el contenido y el nombre de una imagen validada
    /// </summary>
    /// <param name="ruta">ruta del archivo que se va a cargar</param>
    /// <param name="nombre">nombre del archivo o del registro</param>
    /// <param name="campo">nombre del campo que se esta validando</param>
    /// <returns>contenido de la imagen</returns>
    public static byte[] LeerContenido(string ruta, out string nombre, string campo = "Fotos")
    {
        string extension = Path.GetExtension(ruta).ToLowerInvariant();
        if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            throw new ValidacionException(campo, "Solo se permiten fotos .jpg, .jpeg y .png.");
        FileInfo archivo = new FileInfo(ruta);
        if (!archivo.Exists || archivo.Length <= 0 || archivo.Length > MaximoBytes)
            throw new ValidacionException(campo, "La foto debe existir, no estar vacia y pesar como maximo 2 MB.");
        nombre = archivo.Name;
        byte[] contenido = File.ReadAllBytes(ruta);
        List<ErrorValidacion> errores = new List<ErrorValidacion>();
        ValidarContenido(nombre, contenido, errores, campo);
        Validador.LanzarSiHay(errores);
        return contenido;
    }
    // la categoria guarda una lista de fotos y el producto solo tiene una
    /// <summary>
    /// comprueba las reglas de negocio de la entidad
    /// </summary>
    /// <param name="foto">fotografia que se va a revisar</param>
    /// <param name="errores">lista donde se guardan los errores encontrados</param>
    public static void Validar(FotoCategoria foto, List<ErrorValidacion> errores)
    {
        ValidarContenido(foto == null ? null : foto.NombreArchivo, foto == null ? null : foto.Contenido, errores);
    }
    // revisa que el archivo sea una imagen y no solo que termine en .jpg
    /// <summary>
    /// revisa extension, tamano y contenido de la imagen
    /// </summary>
    /// <param name="nombre">nombre del archivo o del registro</param>
    /// <param name="datos">contenido de la fotografia</param>
    /// <param name="errores">lista donde se guardan los errores encontrados</param>
    /// <param name="campo">nombre del campo que se esta validando</param>
    public static void ValidarContenido(string nombre, byte[] datos, List<ErrorValidacion> errores, string campo = "Fotos")
    {
        if (datos == null || datos.Length == 0 || datos.Length > MaximoBytes)
        { errores.Add(new ErrorValidacion(campo, "Cada foto debe tener contenido y pesar como maximo 2 MB.")); return; }
        string extension = Path.GetExtension(nombre ?? "").ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(nombre) || nombre.Length > 260 || (extension != ".jpg" && extension != ".jpeg" && extension != ".png"))
        { errores.Add(new ErrorValidacion(campo, "Usa archivos .jpg, .jpeg o .png con un nombre valido.")); return; }
        try
        {
            using (MemoryStream contenido = new MemoryStream(datos))
            using (Image imagen = Image.FromStream(contenido, false, true))
            {
                bool formato = extension == ".png" ? imagen.RawFormat.Guid == ImageFormat.Png.Guid : imagen.RawFormat.Guid == ImageFormat.Jpeg.Guid;
                if (!formato) errores.Add(new ErrorValidacion(campo, "La extension no coincide con el contenido de la imagen."));
            }
        }
        catch (ArgumentException) { errores.Add(new ErrorValidacion(campo, "El archivo no es una imagen valida.")); }
        catch (OutOfMemoryException) { errores.Add(new ErrorValidacion(campo, "No se pudo leer la imagen. Usa otra foto valida.")); }
    }
}
}
