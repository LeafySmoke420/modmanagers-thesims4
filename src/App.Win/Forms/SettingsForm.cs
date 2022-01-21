using LwdGeeks.ModManagers.TheSims4.App.Win;
using LwdGeeks.ModManagers.TheSims4.App.Win.Extensions;
using LwdGeeks.ModManagers.TheSims4.App.Win.Forms.Common;
using LwdGeeks.ModManagers.TheSims4.App.Win.Models;

namespace App.Win.Forms
{
    public partial class SettingsForm : BaseForm
    {
        private readonly AppSettings _appSettings;

        public SettingsForm()
        {
            _appSettings = Program.AppSettings;

            InitializeComponent();

            ConfigureSettings();

            ConfigureComponents();

            LoadData();
        }

        #region ## Buttons
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!SaveData())
                return;

            if (MessageBoxExt.Confirmation("Settings successfully updated. Close this window?", "Success") == DialogResult.Yes)
                Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BrowseAppDataFolderButton_Click(object sender, EventArgs e)
        {
            BrowseFolder(AppDataFolderText);
        }

        private void BrowseModsFolderButton_Click(object sender, EventArgs e)
        {
            BrowseFolder(ModsFolderText);
        }

        private void BrowseUserProfileFolderButton_Click(object sender, EventArgs e)
        {
            BrowseFolder(UserProfileText);
        }
        #endregion

        #region ## Private
        private void ConfigureComponents()
        {
            BrowserDialog.RootFolder = Environment.SpecialFolder.UserProfile;
        }

        private void LoadData()
        {
            // Folders
            UserProfileText.Text = _appSettings.UserProfileFolder;
            ModsFolderText.Text = _appSettings.ModsFolder;
            AppDataFolderText.Text = _appSettings.AppDataFolder;

            // Extensions
            ModsFilesText.Text = string.Join(',', _appSettings.ModsValidExtensions);
            ImageFilesText.Text = string.Join(',', _appSettings.ImagesValidExtensions);
            TrayFilesText.Text = string.Join(',', _appSettings.TrayValidExtensions);

            // Togles
            LimitBigModsFolderCheckbox.Checked = _appSettings.LimitBigModsFolder;
            SkipConfirmationInstallUninstallCheckbox.Checked = _appSettings.SkipConfirmInstallUninstall;
            SkipSuccessInstallUninstallCheckbox.Checked = _appSettings.SkipSuccessInstallUninstall;
        }

        private bool SaveData()
        {
            var appDataSnapshot = _appSettings.AppDataFolder;

            // Folders
            _appSettings.UserProfileFolder = ValidateFolder(UserProfileLabel, UserProfileText);
            _appSettings.ModsFolder = ValidateFolder(ModsFolderLabel, ModsFolderText);
            _appSettings.AppDataFolder = AppDataFolderText.Text;

            // Extensions
            _appSettings.ModsValidExtensions = CleanAndTrimExtensions(ModsFilesLabel, ModsFilesText);
            _appSettings.ImagesValidExtensions = CleanAndTrimExtensions(ImageFilesLabel, ImageFilesText);
            _appSettings.TrayValidExtensions = CleanAndTrimExtensions(TrayFilesLabel, TrayFilesText);

            // Togles
            _appSettings.LimitBigModsFolder = LimitBigModsFolderCheckbox.Checked;
            _appSettings.SkipConfirmInstallUninstall = SkipConfirmationInstallUninstallCheckbox.Checked;
            _appSettings.SkipSuccessInstallUninstall = SkipSuccessInstallUninstallCheckbox.Checked;

            if (HasErrors())
                return false;

            _appSettings.Save();

            UpdateAppDataFolder();

            return true;

            string ValidateFolder(Label label, TextBox textBox)
            {
                DefaultErrorProvider.SetError(label, string.Empty);

                if (!Directory.Exists(textBox.Text))
                {
                    DefaultErrorProvider.SetError(label, "This folder does not exist.");
                }

                return textBox.Text;
            }

            string[] CleanAndTrimExtensions(Label label, TextBox textBox)
            {
                DefaultErrorProvider.SetError(label, string.Empty);

                var values = textBox.Text.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x));

                var invalidValues = values.Where(x => x.Contains(' ') || !x.StartsWith("."));

                if (invalidValues.Any())
                {
                    DefaultErrorProvider.SetError(label, $"Contains invalid extensions: {string.Join(',', invalidValues)}");
                }

                return values.ToArray();
            }

            bool HasErrors()
            {
                var controls = new[] { UserProfileLabel, ModsFolderLabel, AppDataFolderLabel, ModsFilesLabel, ImageFilesLabel, TrayFilesLabel };

                return controls.Any(x => !string.IsNullOrEmpty(DefaultErrorProvider.GetError(x)));
            }

            void UpdateAppDataFolder()
            {
                if (!appDataSnapshot.Equals(_appSettings.AppDataFolder, StringComparison.InvariantCultureIgnoreCase))
                {
                    Directory.CreateDirectory(appDataSnapshot);

                    appDataSnapshot = @"D:\Downloads\test";

                    foreach (var file in Directory.GetFiles(appDataSnapshot, "*").Select(x => new FileInfo(x)))
                    {
                        file.MoveTo(Path.Combine(AppDataFolderText.Text, file.Name));
                    }

                    Directory.Delete(appDataSnapshot, true);
                }
            }
        }

        private void BrowseFolder(TextBox textBox)
        {
            if (BrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            textBox.Text = BrowserDialog.SelectedPath;
        }
        #endregion
    }
}
