using Autofac;
using GeneralToolkitLib.Configuration;
using AutofacSerilogIntegration;
using Serilog;
using Serilog.Events;
using System.Globalization;

namespace FileSystemImage.Library.AutofacModules
{
    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

           var logLevel = LogEventLevel.Debug;
            if (!ApplicationBuildConfig.DebugMode)
            {
                logLevel = LogEventLevel.Warning;
            }

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(ApplicationBuildConfig.ApplicationLogFilePath(true),
                fileSizeLimitBytes: 5242880,
                retainedFileCountLimit: 20,
                restrictedToMinimumLevel: logLevel,
                buffered: false,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff} [{Level}] {Message}{NewLine}{Exception}{Data}")
                .MinimumLevel.Is(logLevel)
                .CreateLogger();

            builder.RegisterLogger();
        }
    }
}
