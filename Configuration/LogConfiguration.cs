using System.Globalization;
using System.Reflection;
using GeneralToolkitLib.Configuration;
using Serilog;
using Serilog.Events;

namespace FileSystemImage.Configuration
{
    public static class LogConfiguration
    {
        // If debug use executing assembly path otherwise use appdata
        public static void ConfigureSerilog()
        {
            var logLevel = !ApplicationBuildConfig.DebugMode ? LogEventLevel.Warning : LogEventLevel.Verbose;

            Log.Logger = new LoggerConfiguration()
                         .WriteTo.LiterateConsole(LogEventLevel.Debug, standardErrorFromLevel: LogEventLevel.Error, formatProvider: CultureInfo.InvariantCulture)
                         .WriteTo.RollingFile(ApplicationBuildConfig.ApplicationLogFilePath(true),
                             fileSizeLimitBytes: 1048576,
                             retainedFileCountLimit: 31,
                             restrictedToMinimumLevel: logLevel,
                             buffered: false,
                             outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff} [{Level}] {Message}{NewLine}{Exception}{Data}")
                         .Enrich.FromLogContext()
                         .Enrich.WithProperty("Version", Assembly.GetCallingAssembly().GetName().Version.ToString(4))
                         .MinimumLevel.Is(logLevel)
                         .CreateLogger();

        }
    }
}
