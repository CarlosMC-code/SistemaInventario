using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SistemaInventario.Entidades;
using SistemaInventario.LogicaNegocio;
using System.Globalization;
using System.Threading;
namespace SistemaInventario.Presentacion
{
// el programa empieza por aqui
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("es-DO");
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-DO");
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.ThreadException += (sender, e) => ManejoErrores.Mostrar(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => RegistroErrores.Registrar(e.ExceptionObject as Exception);
        // el servidor se cambia en App.config sin tener que editar los formularios
        ServiciosAplicacion servicios = FabricaServicios.Crear();
        while (true)
        {
            using (LoginForm login = new LoginForm(servicios))
            {
                if (login.ShowDialog() != DialogResult.OK) break;
                servicios = login.Servicios;
            }
            using (PrincipalForm principal = new PrincipalForm(servicios))
            {
                principal.ShowDialog();
                if (!principal.CerrarSesion) break;
            }
            servicios.Sesion.Cerrar();
        }
    }
}
}
