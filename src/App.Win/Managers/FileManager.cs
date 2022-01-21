using LwdGeeks.ModManagers.TheSims4.App.Win.Models;
using LwdGeeks.ModManagers.TheSims4.App.Win.Resources;
using System.Text.Json;

namespace LwdGeeks.ModManagers.TheSims4.App.Win.Managers
{
    public class FileManager
    {
        private readonly AppSettings _appSettings;
        private readonly IDictionary<string, (int Index, Image Image)> _imageIcons;

        private FileManager(
            AppSettings appSettings)
        {
            _appSettings = appSettings;
            _imageIcons = new Dictionary<string, (int Index, Image Image)>
            {
                { nameof(AppImages.Package_24), (0, AppImages.Package_24) },
                { nameof(AppImages.Layers_24), (1, AppImages.Layers_24) },
                { nameof(AppImages.Image_24), (2, AppImages.Image_24) },
                { nameof(AppImages.Script_24), (3, AppImages.Script_24) },
            };
            
            Installed = new List<ModInstallationInfo>();
            SelectableExtensions =
                appSettings.ModsValidExtensions.Concat(
                    appSettings.ImagesValidExtensions).Concat(
                        appSettings.TrayValidExtensions).ToArray();
        }

        public static FileManager Create(AppSettings appSettings)
        {
            var manager = new FileManager(appSettings);

            manager.LoadInstalledMods();

            return manager;
        }

        public List<ModInstallationInfo> Installed { get; set; }
        public string[] SelectableExtensions { get; set; }

        public void Install(IEnumerable<FileInfo> files)
        {
            foreach (var fi in files)
            {
                if (IsInstalled(fi))
                    continue;

                var shared = GetSharedFiles(fi);

                foreach (var item in shared)
                    item.Shared = true;

                if (!TryBuildPath(fi, out var path))
                    continue;

                var modInfo = ModInstallationInfo.Create(fi, path, shared.Any());

                if (!modInfo.Shared)
                    fi.CopyTo(modInfo.InstallationPath);

                Installed.Add(modInfo);
            }

            WriteInstallationLog();
        }

        public void Uninstall(IEnumerable<FileInfo> files)
        {
            foreach (var fi in files)
            {
                if (!IsInstalled(fi))
                    continue;

                var shared = GetSharedFiles(fi).ToList();

                if (shared.Count == 1)
                    shared.Single().Shared = false;

                var mod = GetModDetail(fi);

                if (mod == null)
                    continue;

                if (!shared.Any())
                    File.Delete(mod.InstallationPath);

                _ = Installed.Remove(mod);
            }

            WriteInstallationLog();
        }

        public void LoadInstalledMods()
        {
            Installed = File.Exists(_appSettings.InstallationLogFile)
                ? JsonSerializer.Deserialize<List<ModInstallationInfo>>(File.ReadAllText(_appSettings.InstallationLogFile))!
                : new List<ModInstallationInfo>();
        }

        public ModInstallationInfo GetModDetail(FileInfo fi)
        {
            return Installed.SingleOrDefault(x =>
                x.Name.Equals(fi.Name, StringComparison.InvariantCultureIgnoreCase) &&
                x.SourceFile.Equals(fi.FullName, StringComparison.InvariantCultureIgnoreCase))!;
        }

        public bool IsInstalled(FileInfo fi)
        {
            return Installed.Any(x =>
                x.Name.Equals(fi.Name, StringComparison.InvariantCultureIgnoreCase) &&
                x.SourceFile.Equals(fi.FullName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<ModInstallationInfo> GetSharedFiles(FileInfo fi)
        {
            return Installed.Where(x =>
                x.Name.Equals(fi.Name, StringComparison.InvariantCultureIgnoreCase) &&
                !x.SourceFile.Equals(fi.FullName, StringComparison.InvariantCultureIgnoreCase));
        }

        public void ResetAndCleanUp()
        {
            if (!Installed.Any())
                return;

            foreach (var file in Installed)
                File.Delete(file.SourceFile);

            Installed.Clear();

            WriteInstallationLog();
        }

        public bool IsSelectableFile(FileInfo file)
        {
            return SelectableExtensions.Contains(file.Extension.ToLowerInvariant());
        }

        public bool CanBeInstalled(string file)
        {
            return IsModFile(file) || IsTrayFile(file);
        }

        public bool IsModFile(FileInfo file)
        {
            return _appSettings.ModsValidExtensions.Contains(file.Extension.ToLowerInvariant());
        }

        public bool IsModFile(string file)
        {
            return _appSettings.ModsValidExtensions.Contains($".{file.Split('.').Last()}");
        }

        public bool IsTrayFile(FileInfo file)
        {
            return _appSettings.TrayValidExtensions.Contains(file.Extension.ToLowerInvariant());
        }

        public bool IsTrayFile(string file)
        {
            return _appSettings.TrayValidExtensions.Contains($".{file.Split('.').Last()}");
}

        public bool IsImageFile(FileInfo file)
        {
            return _appSettings.ImagesValidExtensions.Contains(file.Extension.ToLowerInvariant());
        }

        public void AddImageIcons(ImageList imageList)
        {
            foreach (var image in _imageIcons)
                imageList.Images.Add(image.Value.Image);
        }

        public int GetImageIconIndex(FileInfo fi)
        {
            if (fi.Extension.Contains("script"))
                return _imageIcons[nameof(AppImages.Script_24)].Index;
            else if (IsTrayFile(fi))
                return _imageIcons[nameof(AppImages.Layers_24)].Index;
            else if (IsImageFile(fi))
                return _imageIcons[nameof(AppImages.Image_24)].Index;
            else
                return _imageIcons[nameof(AppImages.Package_24)].Index;
        }

        public bool TryBuildPath(FileInfo fi, out string path)
        {
            path = string.Empty;

            if (IsModFile(fi))
                path = Path.Combine(_appSettings.UserProfileFolder, "Mods");
            if (IsTrayFile(fi))
                path = Path.Combine(_appSettings.UserProfileFolder, "Tray");
            else
                return false;

            return true;
        }

        private void WriteInstallationLog()
        {
            File.WriteAllText(_appSettings.InstallationLogFile, JsonSerializer.Serialize(Installed));
        }
    }
}