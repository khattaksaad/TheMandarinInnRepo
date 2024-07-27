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
            //Application.Run(new fAccess());
            //check for updates first
            //CheckForUpdatesAsync();
            //Application.Run(new fPrintBill(1,19));
            Application.Run(new fLogin());
        }
        private static async void CheckForUpdatesAsync()
        {
            await UpdateChecker.CheckForUpdates();
        }
    }
}
