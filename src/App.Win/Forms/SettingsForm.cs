using App.Win.Forms.Common;

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
            UserProfileText.Text = Properties.Settings.Default.UserProfileFolder;
            ModsFolderText.Text = Properties.Settings.Default.ModsFolder;
            AppDataFolderText.Text = Properties.Settings.Default.AppDataFolder;

            // Extensions
            ModsFilesText.Text = Properties.Settings.Default.ModsValidExtensions;
            ImageFilesText.Text = Properties.Settings.Default.ImagesValidExtensions;
            TrayFilesText.Text = Properties.Settings.Default.TrayValidExtensions;

            // Togles
            LimitBigModsFolderCheckbox.Checked = Properties.Settings.Default.LimitBigModsFolder;
        }

        private bool SaveData()
        {
            var appDataSnapshot = Properties.Settings.Default.AppDataFolder;

            // Folders
            Properties.Settings.Default.UserProfileFolder = ValidateFolder(UserProfileLabel, UserProfileText);
            Properties.Settings.Default.ModsFolder = ValidateFolder(ModsFolderLabel, ModsFolderText);
            Properties.Settings.Default.AppDataFolder = AppDataFolderText.Text;

            // Extensions
            Properties.Settings.Default.ModsValidExtensions = CleanAndTrimExtensions(ModsFilesLabel, ModsFilesText);
            Properties.Settings.Default.ImagesValidExtensions = CleanAndTrimExtensions(ImageFilesLabel, ImageFilesText);
            Properties.Settings.Default.TrayValidExtensions = CleanAndTrimExtensions(TrayFilesLabel, TrayFilesText);

            // Togles
            Properties.Settings.Default.LimitBigModsFolder = LimitBigModsFolderCheckbox.Checked;

            if (HasErrors())
                return false;

            Properties.Settings.Default.Save();

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

                var values = textBox.Text.Split(',').Select(x => x.Trim());

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
                if (!appDataSnapshot.Equals(Properties.Settings.Default.AppDataFolder, StringComparison.InvariantCultureIgnoreCase))
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
