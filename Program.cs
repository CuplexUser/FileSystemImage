using System;
using System.Windows.Forms;
using FileSystemImage.Configuration;
using Serilog;

namespace FileSystemImage
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Set log path
            //GlobalSettings.Initialize(Application.ProductName, true);
            LogConfiguration.ConfigureSerilog();
            Log.Debug("Application Started");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            Log.Debug("Application Terminated");
        }
    }
}