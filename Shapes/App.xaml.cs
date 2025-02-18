using Shapes.Helpers;
using System;
using System.Windows;

namespace Shapes
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Register global exception handler
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ExceptionHandler.HandleException(e.Exception);
            e.Handled = true;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
        }

        private void LogException(Exception ex)
        {
            // Example: Log to a file
            System.IO.File.AppendAllText("error.log", $"{DateTime.Now}: {ex}\n");
        }
    }
}