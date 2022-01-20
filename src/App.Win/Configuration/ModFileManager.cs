using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace LwdGeeks.ModManagers.TheSims4.App.Win.Configuration
{
    public class ModFileManager
    {
        private readonly string _fileName;
        private static ModFileManager _instance;

        public ModFileManager()
        {
            _fileName = Path.Combine(Properties.Settings.Default.AppDataFolder, "installation_log");

            Installed = new List<ModDetail>();
        }

        public static ModFileManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ModFileManager();

                return _instance;
            }
        }

        public List<ModDetail> Installed { get; set; }

        public void Install(IEnumerable<FileInfo> files)
        {
            foreach (var fi in files)
            {
                if (IsInstalled(fi))
                    continue;

                var shared = GetSharedFiles(fi);

                foreach (var item in shared)
                    item.Shared = true;

                string subfolder;

                if (FileConfiguration.Instance.IsModFile(fi))
                    subfolder = "Mods";
                else if (FileConfiguration.Instance.IsTrayFile(fi))
                    subfolder = "Tray";
                else
                    continue;

                var modDetail = ModDetail.Create(fi, Path.Combine(Properties.Settings.Default.UserProfileFolder, subfolder), shared.Any());

                if (!modDetail.Shared)
                    fi.CopyTo(modDetail.InstallationPath);

                Installed.Add(modDetail);
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
            Installed = File.Exists(_fileName)
                ? JsonSerializer.Deserialize<List<ModDetail>>(File.ReadAllText(_fileName))!
                : new List<ModDetail>();
        }

        public ModDetail GetModDetail(FileInfo fi)
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

        public IEnumerable<ModDetail> GetSharedFiles(FileInfo fi)
        {
            return Installed.Where(x =>
                x.Name.Equals(fi.Name, StringComparison.InvariantCultureIgnoreCase) &&
                !x.SourceFile.Equals(fi.FullName, StringComparison.InvariantCultureIgnoreCase));
        }

        private void WriteInstallationLog()
        {
            File.WriteAllText(_fileName, JsonSerializer.Serialize(Installed));
        }
    }
}