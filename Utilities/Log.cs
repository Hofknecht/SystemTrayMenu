// <copyright file="Log.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using Clearcove.Logging;
    using File = System.IO.File;

    internal static class Log
    {
        private const string LogfileLastExtension = "_last";
        private static readonly Logger LogValue = new(string.Empty);
        private static readonly List<string> Warnings = new();
        private static readonly List<string> Infos = new();

        internal static void Initialize()
        {
            bool warnFailedToSaveLogFile = false;
            Exception exceptionWarnFailedToSaveLogFile = new();
            if (Properties.Settings.Default.SaveLogFileInApplicationDirectory)
            {
                try
                {
                    string fileNameToCheckWriteAccess = "CheckWriteAccess";
                    File.WriteAllText(fileNameToCheckWriteAccess, fileNameToCheckWriteAccess);
                    File.Delete(fileNameToCheckWriteAccess);
                }
                catch (Exception ex)
                {
                    Properties.Settings.Default.SaveLogFileInApplicationDirectory = false;
                    warnFailedToSaveLogFile = true;
                    exceptionWarnFailedToSaveLogFile = ex;
                }
            }

            bool warnCanNotClearLogfile = false;
            Exception exceptionWarnCanNotClearLogfile = new();
            string fileNamePath = GetLogFilePath();
            FileInfo fileInfo = new(fileNamePath);
            string fileNamePathLast = string.Empty;
            if (fileInfo.Exists && fileInfo.Length > 2000000)
            {
                fileNamePathLast = GetLogFilePath(LogfileLastExtension);

                try
                {
                    File.Delete(fileNamePathLast);
                    File.Move(fileNamePath, fileNamePathLast);
                }
                catch (Exception ex)
                {
                    warnCanNotClearLogfile = true;
                    exceptionWarnCanNotClearLogfile = ex;
                }
            }

            Logger.Start(fileInfo);

            if (warnFailedToSaveLogFile)
            {
                Warn($"Failed to save log file in application folder {GetLogFilePath()}", exceptionWarnFailedToSaveLogFile);
            }

            if (warnCanNotClearLogfile)
            {
                Warn($"Can not clear logfile:'{fileNamePathLast}'", exceptionWarnCanNotClearLogfile);
            }
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

        internal static string GetLogFilePath(string backup = "")
        {
            string logFilePath = string.Empty;
            if (!Properties.Settings.Default.SaveLogFileInApplicationDirectory)
            {
                logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"SystemTrayMenu");
            }

            return Path.Combine(logFilePath, $"log-{Environment.MachineName}{backup}.txt");
        }

        internal static void OpenLogFile()
        {
            string lastLogfile = GetLogFilePath(LogfileLastExtension);
            if (File.Exists(lastLogfile))
            {
                ProcessStart(lastLogfile);
            }

            ProcessStart(GetLogFilePath());
        }

        internal static void WriteApplicationRuns()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Version? version = assembly.GetName().Version;
            LogValue.Info($"Application Start " +
                assembly.ManifestModule.Name + " | " +
                (version != null ? version.ToString() : string.Empty) + " | " +
                $"ScalingFactor={Scaling.Factor}");
        }

        internal static void Close()
        {
            try
            {
                Logger.ShutDown();
            }
            catch (Exception ex)
            {
                Properties.Settings.Default.SaveLogFileInApplicationDirectory = false;
                Warn($"Failed to save log file in application folder {GetLogFilePath()}", ex);
            }
        }

        internal static void ProcessStart(
            string fileName,
            string arguments = "",
            bool doubleQuoteArg = false,
            string? workingDirectory = null,
            bool createNoWindow = false,
            string resolvedPath = "")
        {
            if (doubleQuoteArg && !string.IsNullOrEmpty(arguments))
            {
                arguments = "\"" + arguments + "\"";
            }

            try
            {
                string verb = string.Empty;
                if (!PrivilegeChecker.IsCurrentUserInAdminGroup)
                {
                    bool isLink = Path.GetExtension(fileName)
                        .Equals(".lnk", StringComparison.InvariantCultureIgnoreCase);
                    if (isLink)
                    {
                        Type? shellType = Type.GetTypeFromProgID("WScript.Shell");
                        if (shellType != null)
                        {
                            object shell = Activator.CreateInstance(shellType)!;
                            object? shortcut = shellType.InvokeMember(
                                "CreateShortcut",
                                BindingFlags.InvokeMethod,
                                binder: null,
                                target: shell,
                                args: new object[] { fileName });
                            if (shortcut == null)
                            {
                                Log.Info($"CreateShortcut returned null for path:'{fileName}'");
                                goto StartProcess;
                            }

                            Type shortcutType = shortcut.GetType();
                            object? windowStyleObject = shortcutType.InvokeMember(
                                "WindowStyle",
                                BindingFlags.GetProperty,
                                binder: null,
                                target: shortcut,
                                args: null);
                            int windowStyle = windowStyleObject is int style ? style : 0;
                            bool startAsAdmin = windowStyle == 3;
                            if (startAsAdmin)
                            {
                                verb = "runas";
                            }

                            if (Marshal.IsComObject(shortcut))
                            {
                                _ = Marshal.FinalReleaseComObject(shortcut);
                            }

                            if (Marshal.IsComObject(shell))
                            {
                                _ = Marshal.FinalReleaseComObject(shell);
                            }
                        }
                    }
                }

                StartProcess:
                using Process p = new()
                {
                    StartInfo = new ProcessStartInfo(fileName)
                    {
                        FileName = fileName,
                        Arguments = arguments,
                        WorkingDirectory = workingDirectory ?? string.Empty,
                        CreateNoWindow = createNoWindow,
                        UseShellExecute = true,
                        Verb = verb,
                    },
                };
                p.Start();
            }
            catch (Win32Exception ex)
            {
                Warn($"fileName:'{fileName}' arguments:'{arguments}'", ex);

                if ((ex.NativeErrorCode == 2 || ex.NativeErrorCode == 1223) &&
                    (string.IsNullOrEmpty(resolvedPath) || !File.Exists(resolvedPath)))
                {
                    new Thread(ShowProblemWithShortcut).Start();
                    static void ShowProblemWithShortcut()
                    {
                        _ = MessageBox.Show(
                            Translator.GetText("The item that this shortcut refers to has been changed or moved, so this shortcut will no longer work properly."),
                            Translator.GetText("Problem with shortcut link"),
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Warn($"fileName:'{fileName}' arguments:'{arguments}'", ex);
            }
        }
    }
}
