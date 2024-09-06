using HotelManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Set up global exception handling
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(GlobalExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalUnhandledExceptionHandler);
            Application.Run(new fLogin());
        }

        private static void GlobalExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // Log the exception
            AppLogger.Instance.LogError("Unhandled UI exception occurred.", e.Exception);

            // Optionally show a message box or other user feedback
            MessageBox.Show("An unexpected error occurred. The error has been logged.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            // Log the exception
            Exception exception = (Exception)e.ExceptionObject;
            AppLogger.Instance.LogError("Unhandled non-UI exception occurred.", exception);

            // Optionally handle the application exit
            // Environment.Exit(1);
        }
    }
}
