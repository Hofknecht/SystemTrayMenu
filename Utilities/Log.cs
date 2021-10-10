// <copyright file="Log.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using Clearcove.Logging;

    internal static class Log
    {
        private static readonly Logger LogValue = new Logger(string.Empty);
        private static readonly List<string> Warnings = new List<string>();
        private static readonly List<string> Infos = new List<string>();

        internal static void Initialize()
        {
            Logger.Start(new FileInfo(GetLogFilePath()));
        }

        internal static void Info(string message)
        {
            if (!Infos.Contains(message))
            {
                Infos.Add(message);
                LogValue.Info(message);
            }
        }

        internal static void Warn(string message, Exception ex)
        {
            string warning = $"{message} {ex.ToString().Replace(Environment.NewLine, " ", StringComparison.InvariantCulture)}";
            if (!Warnings.Contains(warning))
            {
                Warnings.Add(warning);
                LogValue.Warn(warning);
            }
        }

        internal static void Error(string message, Exception ex)
        {
            LogValue.Error($"{message}{Environment.NewLine}" +
                $"{ex}");
        }

        internal static string GetLogFilePath()
        {
            return Path.Combine(
                Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                $"SystemTrayMenu"),
                $"log-{Environment.MachineName}.txt");
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

        internal static void ProcessStart(
            string fileName,
            string arguments = "",
            bool doubleQuoteArg = false,
            string workingDirectory = "",
            bool createNoWindow = false)
        {
            if (doubleQuoteArg && !string.IsNullOrEmpty(arguments))
            {
                arguments = "\"" + arguments + "\"";
            }

            try
            {
                using Process p = new Process
                {
                    StartInfo = new ProcessStartInfo(fileName)
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        WorkingDirectory = workingDirectory,
                        CreateNoWindow = createNoWindow,
                        UseShellExecute = true,
                    },
                };
                p.Start();
            }
            catch (Exception ex)
            {
                Warn($"fileName:'{fileName}' arguments:'{arguments}'", ex);
                if (ex.Message == "The system cannot find the file specified.")
                {
                    new Thread(ShowProblemWithShortcut).Start();
                    void ShowProblemWithShortcut()
                    {
                        _ = MessageBox.Show(
                            Translator.GetText("The item that this shortcut refers to has been changed or moved, so this shortcut will no longer work properly."),
                            Translator.GetText("Problem with Shortcut"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
