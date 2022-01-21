using LwdGeeks.ModManagers.TheSims4.App.Win.Extensions;
using LwdGeeks.ModManagers.TheSims4.App.Win.Properties;

namespace LwdGeeks.ModManagers.TheSims4.App.Win.Models
{
    public class AppSettings
    {
        private AppSettings(
            string userProfileFolder,
            string appDataFolder)
        {
            AppVersion = "1.0.22021.1-beta";
            UserProfileFolder = userProfileFolder;
            AppDataFolder = appDataFolder;

            if (UserProfileFolder.IsEmpty())
                UserProfileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Documents\\Electronic Arts\\The Sims 4");

            if (AppDataFolder.IsEmpty())
            {
                AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "The Sims 4 - Mod Manager");

                Directory.CreateDirectory(AppDataFolder);
            }

            AppLogFile = Path.Combine(AppDataFolder!, "app_log");
            InstallationLogFile = Path.Combine(AppDataFolder!, "installation_log");
        }

        public string AppVersion { get; set; }
        public string UserProfileFolder { get; set; }
        public string ModsFolder { get; set; }
        public string AppDataFolder { get; set; }
        public string[] ModsValidExtensions { get; set; }
        public string[] TrayValidExtensions { get; set; }
        public string[] ImagesValidExtensions { get; set; }
        public bool LimitBigModsFolder { get; set; }
        public bool HideTrayFiles { get; set; }
        public bool SkipConfirmInstallUninstall { get; set; }
        public bool SkipSuccessInstallUninstall { get; set; }
        public string AppLogFile { get; }
        public string InstallationLogFile { get; }

        public static AppSettings Load()
        {
            var appSettings = new AppSettings(
                Settings.Default.UserProfileFolder,
                Settings.Default.AppDataFolder
                )
            {
                ModsFolder = Settings.Default.ModsFolder,
                ModsValidExtensions = Settings.Default.ModsValidExtensions.Split(','),
                TrayValidExtensions = Settings.Default.TrayValidExtensions.Split(','),
                ImagesValidExtensions = Settings.Default.ImagesValidExtensions.Split(','),
                LimitBigModsFolder = Settings.Default.LimitBigModsFolder,
                HideTrayFiles = Settings.Default.HideTrayFiles,
                SkipConfirmInstallUninstall = Settings.Default.SkipConfirmInstallUninstall,
                SkipSuccessInstallUninstall = Settings.Default.SkipSuccessInstallUninstall,
            };

            appSettings.Save();

            return appSettings;
        }

        public void Save()
        {
            Settings.Default.UserProfileFolder = UserProfileFolder;
            Settings.Default.ModsFolder = ModsFolder;
            Settings.Default.AppDataFolder = AppDataFolder;
            Settings.Default.ModsValidExtensions = string.Join(',', ModsValidExtensions);
            Settings.Default.TrayValidExtensions = string.Join(',', TrayValidExtensions);
            Settings.Default.ImagesValidExtensions = string.Join(',', ImagesValidExtensions);
            Settings.Default.LimitBigModsFolder = LimitBigModsFolder;
            Settings.Default.HideTrayFiles = HideTrayFiles;
            Settings.Default.SkipConfirmInstallUninstall = SkipConfirmInstallUninstall;
            Settings.Default.SkipSuccessInstallUninstall = SkipSuccessInstallUninstall;

            Settings.Default.Save();
        }
    }
}