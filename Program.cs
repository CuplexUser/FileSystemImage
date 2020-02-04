using System;
using System.Text;
using System.Windows.Forms;
using FileSystemImage.Configuration;
using Serilog;

namespace FileSystemImage
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="parameters"></param>
        [STAThread]
        private static void Main(string[] parameters)
        {

            //Set log path
            LogConfiguration.ConfigureSerilog();
            Log.Debug("Application Started");

            // Parse commands if c parameter string is not empty
            if (parameters.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < parameters.Length; i++)
                {
                    sb.Append($"{(i + 1)}: {parameters[i]}, ");
                }

                string argumentStr = sb.ToString().TrimEnd(", ".ToCharArray());
                Log.Information("Application started with argumentStr {}", 2);
                MessageBox.Show("Application input parameters not yet implemented", "Please observe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            Log.Debug("Application Terminated");
        }
    }
}