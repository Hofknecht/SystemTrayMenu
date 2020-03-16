using Clearcove.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SystemTrayMenu.Helper
{
    internal static class Log
    {
        static Logger log = new Logger("");
        internal static void Initialize()
        {
            Logger.Start(new FileInfo(GetLogFilePath()));
        }

        internal static void Info(string message)
        {
            log.Info(message);
        }

        internal static void Warn(string message)
        {
            log.Warn($"{message}{Environment.NewLine}" +
                $"{Environment.StackTrace.ToString()}");
        }
        internal static void Error(string message, Exception ex)
        {
            log.Error($"{message}{Environment.NewLine}" +
                $"{ex.ToString()}");
        }

        internal static string GetLogFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(
               Assembly.GetExecutingAssembly().Location),
                   $"log-{Environment.MachineName}.txt");
        }

        internal static void OpenLogFile()
        {
            Process.Start(GetLogFilePath());
        }

        internal static void ApplicationRun()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            log.Info($"Application Start " +
                assembly.ManifestModule.Name + " | " +
                assembly.GetName().Version.ToString() + " | " +
                $"ScalingFactor={Scaling.Factor}");
        }
    }
}
