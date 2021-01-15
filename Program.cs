using Autofac;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using GeneralToolkitLib.ConfigHelper;
using GeneralToolkitLib.Configuration;
using FileSystemImage.Configuration;
using Serilog;


namespace FileSystemImage
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static IContainer Container { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="parameters"></param>
        [STAThread]
        private static void Main()
        {
            InitializeAutofac();

            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            bool debugMode = ApplicationBuildConfig.DebugMode;
            GlobalSettings.Initialize(Assembly.GetExecutingAssembly().GetName().Name, !debugMode);

            // Parse commands if c parameter string is not empty
            //if (parameters.Length > 0)
            //{
            //    var sb = new StringBuilder();
            //    for (int i = 0; i < parameters.Length; i++)
            //    {
            //        sb.Append($"{(i + 1)}: {parameters[i]}, ");
            //    }

            //    Log.Information("Application started with argumentStr {}", 2);
            //    MessageBox.Show("Application input parameters not yet implemented", "Please observe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            Log.Information("Application started");




            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                Task.Delay(1000);
                try
                {

                    FormMain frmMain = scope.Resolve<FormMain>();
                    Application.Run(frmMain);
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "Main program failureException: {Message}", ex.Message);
                }
            }




        }
        private static void InitializeAutofac()
        {
            Container = AutofacConfig.CreateContainer();
        }
    }
}