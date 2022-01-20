using LwdGeeks.ModManagers.TheSims4.App.Win.Resources;

namespace LwdGeeks.ModManagers.TheSims4.App.Win.Configuration
{
    public class FileConfiguration
    {
        private readonly IDictionary<string, (int Index, Image Image)> _imageIcons;

        private static FileConfiguration _instance;

        public FileConfiguration()
        {
            Mods = Properties.Settings.Default.ModsValidExtensions.Split(',').Select(x => x.Trim()).ToArray();
            Tray = Properties.Settings.Default.TrayValidExtensions.Split(',').Select(x => x.Trim()).ToArray();
            Images = Properties.Settings.Default.ImagesValidExtensions.Split(',').Select(x => x.Trim()).ToArray();

            Selectable = Mods.Concat(Images).Concat(Tray).ToArray();

            _imageIcons = new Dictionary<string, (int Index, Image Image)>
            {
                { nameof(AppImages.Package_24), (0, AppImages.Package_24) },
                { nameof(AppImages.Layers_24), (1, AppImages.Layers_24) },
                { nameof(AppImages.Image_24), (2, AppImages.Image_24) },
                { nameof(AppImages.Script_24), (3, AppImages.Script_24) },
            };
        }

        public static FileConfiguration Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FileConfiguration();

                return _instance;
            }
        }

        public string[] Mods { get; private set; }
        public string[] Tray { get; private set; }
        public string[] Images { get; private set; }
        public string[] Selectable { get; private set; }

        public bool IsSelectableFile(FileInfo file)
        {
            return Selectable.Contains(file.Extension.ToLowerInvariant());
        }

        public bool CanBeInstalled(string file)
        {
            return IsModFile(file) || IsTrayFile(file);
        }

        public bool IsModFile(FileInfo file)
        {
            return Mods.Contains(file.Extension.ToLowerInvariant());
        }

        public bool IsModFile(string file)
        {
            return Mods.Contains($".{file.Split('.').Last()}");
        }

        public bool IsTrayFile(FileInfo file)
        {
            return Tray.Contains(file.Extension.ToLowerInvariant());
        }

        public bool IsTrayFile(string file)
        {
            return Tray.Contains($".{file.Split('.').Last()}");
        }

        public bool IsImageFile(FileInfo file)
        {
            return Images.Contains(file.Extension.ToLowerInvariant());
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
    }
}