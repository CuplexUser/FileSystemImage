using System.Globalization;
using System.Reflection;
using System.Text;
using GeneralToolkitLib.Configuration;
using Serilog;
using Serilog.Events;

namespace FileSystemImage.Configuration
{
    public static class LogConfiguration
    {
        // If debug use executing assembly path otherwise use app-data
        public static void ConfigureSerilog()
        {
            var logLevel = !ApplicationBuildConfig.DebugMode ? LogEventLevel.Warning : LogEventLevel.Verbose;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Debug, standardErrorFromLevel: LogEventLevel.Error, formatProvider: CultureInfo.InvariantCulture)
                .WriteTo.File(ApplicationBuildConfig.ApplicationLogFilePath(true),
                    fileSizeLimitBytes: 5242880,
                    retainedFileCountLimit: 20,
                    restrictedToMinimumLevel: logLevel,
                    buffered: false,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff} [{Level}] {Message}{NewLine}{Exception}{Data}",
                    encoding: Encoding.UTF8, formatProvider: CultureInfo.CurrentCulture,
                    rollingInterval: RollingInterval.Day
                    )
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Version", Assembly.GetCallingAssembly().GetName().Version.ToString(4))
                .MinimumLevel.Is(logLevel)
                .CreateLogger();

        }
    }
}
