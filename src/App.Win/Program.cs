using App.Win;
using LwdGeeks.ModManagers.TheSims4.App.Win.Extensions;
using LwdGeeks.ModManagers.TheSims4.App.Win.Managers;
using LwdGeeks.ModManagers.TheSims4.App.Win.Models;
using System.Diagnostics;
using System.Text.Json;

namespace LwdGeeks.ModManagers.TheSims4.App.Win
{
    internal static class Program
    {
        public static AppSettings AppSettings { get; private set; } = default!;
        public static FileManager FileManager { get; private set; } = default!;

        [STAThread]
        static void Main()
        {
            LoadAndSetupData();

            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                // this is a complete garbage solution, jesus.

                var fi = new FileInfo(AppSettings.AppLogFile);

                var logs = new List<AppLog>();

                if (fi.Exists)
                {
                    if (fi.Length > 10485760)
                        fi.Delete();
                    else
                        logs = JsonSerializer.Deserialize<List<AppLog>>(File.ReadAllText(fi.FullName));
                }

                var entry = AppLog.Create("Unexpected error", e);

                logs!.Add(entry);

                File.WriteAllText(fi.FullName, JsonSerializer.Serialize(logs));

                if (MessageBoxExt.Confirmation($"Something happened and the app will shutdown.\n\nYour reference is `{entry.Reference}`, open the logs?", "Error") == DialogResult.Yes)
                {
                    Clipboard.SetText(entry.Reference);

                    Process.Start("notepad.exe", fi.FullName);
                }
            }
        }

        private static void LoadAndSetupData()
        {
            AppSettings = AppSettings.Load();
            FileManager = FileManager.Create(AppSettings);
        }
    }
}