using Clearcove.Logging;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace SystemTrayMenu.Utilities
{
    internal static class Log
    {
        private static readonly Logger log = new Logger("");
        internal static void Initialize()
        {
            Logger.Start(new FileInfo(GetLogFilePath()));
        }

        internal static void Info(string message)
        {
            log.Info(message);
        }

        internal static void Warn(string message, Exception ex)
        {
            log.Warn($"{message}{Environment.NewLine}" +
                $"{ex.ToString()}");
        }

        //internal static void Debug(string message)
        //{
        //    log.Debug($"{message}{Environment.NewLine}" +
        //        $"{Environment.StackTrace.ToString()}");
        //}

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
            ProcessStart(GetLogFilePath());
        }

        internal static void WriteApplicationRuns()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            log.Info($"Application Start " +
                assembly.ManifestModule.Name + " | " +
                assembly.GetName().Version.ToString() + " | " +
                $"ScalingFactor={Scaling.Factor}");
        }

        internal static void Close()
        {
            Logger.ShutDown();
        }

        internal static void ProcessStart(string fileName, string arguments = null)
        {
            if (!string.IsNullOrEmpty(arguments) &&
                !Directory.Exists(arguments))
            {
                Exception ex = new DirectoryNotFoundException();
                Warn($"path:'{arguments}'", ex);
                MessageBox.Show(ex.Message);
            }
            else
            {
                try
                {
                    //if (!string.IsNullOrEmpty(arguments))
                    //{
                        Process.Start(fileName, arguments);
                    //}
                    //else
                    //{
                    //    Process.Start(fileName);
                    //}
                }
                catch (Exception ex)
                {
                    if (ex is FileNotFoundException ||
                        ex is Win32Exception)
                    {
                        Warn($"fileName:'{fileName}' arguments:'{arguments}'", ex);
                        MessageBox.Show(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
