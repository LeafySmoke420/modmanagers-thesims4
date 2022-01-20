using App.Win;
using LwdGeeks.ModManagers.TheSims4.App.Win.Configuration;
using System.Diagnostics;
using System.Text.Json;

namespace LwdGeeks.ModManagers.TheSims4.App.Win
{
    internal static class Program
    {
        public static ModFileManager ModsInfo { get; private set; } = default!;
        public static FileConfiguration FileConfiguration { get; private set; } = default!;

        [STAThread]
        static void Main()
        {
            FileConfiguration = FileConfiguration.Instance;
            ModsInfo = ModFileManager.Instance;

            LoadAndSetupData();

            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                // this is a complete garbage solution, jesus.

                var fi = new FileInfo(Path.Combine(Properties.Settings.Default.AppDataFolder, "app_log"));

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

                if (MessageBox.Show($"Something happened and the app will shutdown.\n\nYour reference is `{entry.Reference}`, open the logs?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    Clipboard.SetText(entry.Reference);

                    Process.Start("notepad.exe", fi.FullName);
                }
            }
        }

        private static void LoadAndSetupData()
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.UserProfileFolder))
            {
                Properties.Settings.Default.UserProfileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents\\Electronic Arts\\The Sims 4");
                Properties.Settings.Default.Save();
            }

            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.AppDataFolder))
            {
                Properties.Settings.Default.AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "The Sims 4 - Mod Manager");
                Directory.CreateDirectory(Properties.Settings.Default.AppDataFolder);
                Properties.Settings.Default.Save();
            }

            ModsInfo.LoadInstalledMods();
        }
    }
}