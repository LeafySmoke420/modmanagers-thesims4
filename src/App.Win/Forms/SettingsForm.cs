using LwdGeeks.ModManagers.TheSims4.App.Win.Forms.Common;
using LwdGeeks.ModManagers.TheSims4.App.Win.Properties;

namespace App.Win.Forms
{
    public partial class SettingsForm : BaseForm
    {
        public SettingsForm()
        {
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

            var result = MessageBox.Show("Settings successfully updated. Close this window?", "Success", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
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
            UserProfileText.Text = Settings.Default.UserProfileFolder;
            ModsFolderText.Text = Settings.Default.ModsFolder;
            AppDataFolderText.Text = Settings.Default.AppDataFolder;

            // Extensions
            ModsFilesText.Text = Settings.Default.ModsValidExtensions;
            ImageFilesText.Text = Settings.Default.ImagesValidExtensions;
            TrayFilesText.Text = Settings.Default.TrayValidExtensions;

            // Togles
            LimitBigModsFolderCheckbox.Checked = Settings.Default.LimitBigModsFolder;
        }

        private bool SaveData()
        {
            var appDataSnapshot = Settings.Default.AppDataFolder;

            // Folders
            Settings.Default.UserProfileFolder = ValidateFolder(UserProfileLabel, UserProfileText);
            Settings.Default.ModsFolder = ValidateFolder(ModsFolderLabel, ModsFolderText);
            Settings.Default.AppDataFolder = AppDataFolderText.Text;

            // Extensions
            Settings.Default.ModsValidExtensions = CleanAndTrimExtensions(ModsFilesLabel, ModsFilesText);
            Settings.Default.ImagesValidExtensions = CleanAndTrimExtensions(ImageFilesLabel, ImageFilesText);
            Settings.Default.TrayValidExtensions = CleanAndTrimExtensions(TrayFilesLabel, TrayFilesText);

            // Togles
            Settings.Default.LimitBigModsFolder = LimitBigModsFolderCheckbox.Checked;

            if (HasErrors())
                return false;

            Settings.Default.Save();

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

            string CleanAndTrimExtensions(Label label, TextBox textBox)
            {
                DefaultErrorProvider.SetError(label, string.Empty);

                var values = textBox.Text.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x));

                var invalidValues = values.Where(x => x.Contains(' ') || !x.StartsWith("."));

                if (invalidValues.Any())
                {
                    DefaultErrorProvider.SetError(label, $"Contains invalid extensions: {string.Join(',', invalidValues)}");
                }

                return string.Join(',', values);
            }

            bool HasErrors()
            {
                var controls = new[] { UserProfileLabel, ModsFolderLabel, AppDataFolderLabel, ModsFilesLabel, ImageFilesLabel, TrayFilesLabel };

                return controls.Any(x => !string.IsNullOrEmpty(DefaultErrorProvider.GetError(x)));
            }

            void UpdateAppDataFolder()
            {
                if (!appDataSnapshot.Equals(Settings.Default.AppDataFolder, StringComparison.InvariantCultureIgnoreCase))
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
