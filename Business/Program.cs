using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using SystemTrayMenu.Utilities;

namespace SystemTrayMenu
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            try
            {
                Log.Initialize();
                SingleAppInstance.Initialize();
                Language.Initialize();

                Config.UpgradeIfNotUpgraded();
                if (Config.LoadOrSetByUser())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.ThreadException += ThreadException;
                    void ThreadException(object s, ThreadExceptionEventArgs t)
                    {
                        AskUserSendError(t.Exception);
                    }

                    Scaling.Initialize();
                    FolderOptions.Initialize();

                    using (new SystemTrayMenu())
                    {
                        Log.WriteApplicationRuns();
                        Application.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                AskUserSendError(ex);
            }
            finally
            {
                Log.Close();
            }

            void AskUserSendError(Exception ex)
            {
                Log.Error("Application Crashed", ex);

#warning [Feature] When Error ask user to send us #47, todo own dialog, lines here too long
                if (MessageBox.Show("A problem has been encountered and the application needs to restart. " +
                    "Reporting this error will help us make our product better. Press yes to open your standard email app.",
                    "SystemTrayMenu BugSplat", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("mailto:" + "markus@hofknecht.eu" +
                        "?subject=SystemTrayMenu Bug reported" +
                        "&body=" + ex.ToString());
                }

                AppRestart.ByThreadException();
            }
        }
    }
}