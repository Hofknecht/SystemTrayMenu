// <copyright file="Log.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Clearcove.Logging;

    internal static class Log
    {
        private static readonly Logger LogValue = new Logger(string.Empty);

        internal static void Initialize()
        {
            Logger.Start(new FileInfo(GetLogFilePath()));
        }

        internal static void Info(string message)
        {
            LogValue.Info(message);
        }

        internal static void Warn(string message, Exception ex)
        {
            LogValue.Warn($"{message}{Environment.NewLine}{ex}");
        }

        internal static void Error(string message, Exception ex)
        {
            LogValue.Error($"{message}{Environment.NewLine}" +
                $"{ex}");
        }

        internal static string GetLogFilePath()
        {
            return Path.Combine(
                Path.GetDirectoryName(
               Assembly.GetExecutingAssembly().Location), $"log-{Environment.MachineName}.txt");
        }

        internal static void OpenLogFile()
        {
            ProcessStart(GetLogFilePath());
        }

        internal static void WriteApplicationRuns()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            LogValue.Info($"Application Start " +
                assembly.ManifestModule.Name + " | " +
                assembly.GetName().Version.ToString() + " | " +
                $"ScalingFactor={Scaling.Factor}");
        }

        internal static void Close()
        {
            Logger.ShutDown();
        }

        internal static void ProcessStart(string fileName, string arguments = null, bool doubleQuoteArg = false)
        {
            if (doubleQuoteArg && arguments != null)
            {
                arguments = "\"" + arguments + "\"";
            }

            try
            {
                using Process p = new Process
                {
                    StartInfo = new ProcessStartInfo(fileName)
                    {
                        Arguments = arguments,
                        UseShellExecute = true,
                    },
                };
                p.Start();
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
