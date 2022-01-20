using App.Win.Forms;
using App.Win.Forms.Common;
using LwdGeeks.ModManagers.TheSims4.App.Win;
using LwdGeeks.ModManagers.TheSims4.App.Win.Forms.Common;
using LwdGeeks.ModManagers.TheSims4.App.Win.Properties;
using LwdGeeks.ModManagers.TheSims4.App.Win.Resources;
using System.Diagnostics;
using System.Text;

namespace App.Win
{
    public partial class MainForm : BaseForm
    {
        private readonly List<DirectoryInfo> _modDirectories;
        private readonly List<ListViewItem> _fileItems;
        private readonly List<FileInfo> _rawFiles;
        private IEnumerable<FileInfo> _selectedModFiles;

        public MainForm()
        {
            _modDirectories = new List<DirectoryInfo>();
            _fileItems = new List<ListViewItem>();
            _rawFiles = new List<FileInfo>();
            _selectedModFiles = new List<FileInfo>();

            InitializeComponent();

            ConfigureMain();
        }

        #region ## Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigureComponents();

            LoadData();
        }

        private void FileList_MouseClick(object sender, MouseEventArgs e)
        {
            if (FileList.SelectedItems.Count == 0)
                return;

            var file = _rawFiles.SingleOrDefault(x => x.FullName == FileList.SelectedItems[0].Tag.ToString()!);

            PreviewImageButton.Enabled = file != null && Program.FileConfiguration.IsImageFile(file);
        }

        private void ModsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null || e.Node.Text == "Mods")
                return;

            var folder = _modDirectories.SingleOrDefault(x => x.FullName == e.Node.Tag.ToString());

            if (folder == null)
                return;

            PopulateItemsForSelectedMod(folder.FullName);
        }
        #endregion

        #region ## Buttons
        private void BrowseModsFolder_Click(object sender, EventArgs e)
        {
            BrowseFolder(ModsFolderText);

            RefreshModsFolderMenuButton_Click(default!, default!);
        }

        private void BrowseUserProfileFolder_Click(object sender, EventArgs e)
        {
            BrowseFolder(UserProfileFolderText);
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Program.ModsInfo.Install(FileList.CheckedItems.Cast<ListViewItem>().Select(x => new FileInfo(x.Tag.ToString()!)));

            Cursor = Cursors.Default;

            MessageBox.Show("Successfully installed the selected mods.");
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            Program.ModsInfo.Uninstall(FileList.CheckedItems.Cast<ListViewItem>().Select(x => new FileInfo(x.Tag.ToString()!)));

            Cursor = Cursors.Default;

            RefreshSelected();

            MessageBox.Show("Successfully uninstalled the selected mods.");
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FileList.Items)
            {
                if (Program.FileConfiguration.CanBeInstalled(item.Tag.ToString()!))
                    item.Checked = true;
            }
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FileList.Items)
                item.Checked = false;
        }

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            if (ModsTreeView.SelectedNode.Tag == null)
                return;

            OpenInExplorer(ModsTreeView.SelectedNode.Tag.ToString()!);
        }

        private void PreviewImageButton_Click(object sender, EventArgs e)
        {
            var file = _rawFiles.SingleOrDefault(x => x.FullName == FileList.SelectedItems[0].Tag.ToString()!);

            if (file == null || !Program.FileConfiguration.IsImageFile(file))
                return;

            PreviewImageForm.Instance.UpdateText($"Preview: {file.Name}");
            PreviewImageForm.Instance.UpdatePicture(file.FullName);

            PreviewImageForm.Instance.Show();
        }

        private void SettingsMenuButton_Click(object sender, EventArgs e)
        {
            var _ = new SettingsForm().ShowDialog();

            LoadData();

            RefreshModsFolderMenuButton_Click(default!, default!);
        }

        private void PreviewImagesButton_Click(object sender, EventArgs e)
        {
            if (FileList.Items.Count < 1)
                return;

            var sb = new StringBuilder();

            var selectedFolder = ModsTreeView.SelectedNode.Tag.ToString()!;
            
            var files = Directory.EnumerateFiles(selectedFolder!, "*", SearchOption.AllDirectories).Select(x => new FileInfo(x)).Where(x => Program.FileConfiguration.IsImageFile(x));

            if (!files.Any())
            {
                MessageBox.Show("No images to show on this folder. =/", "No Images", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            foreach (var file in files)
            {
                sb.AppendLine(AppTemplates.HtmlPreviewCheatSheetCard
                    .Replace("@DIRECTORY", file.DirectoryName!.Replace(selectedFolder, string.Empty))
                    .Replace("@FULLNAME", file.FullName)
                    .Replace("@NAME", file.Name));
            }

            var previewHtml = Path.Combine(Settings.Default.AppDataFolder, "previewcheatsheet.html");

            File.WriteAllText(previewHtml, AppTemplates.HtmlPreviewCheatSheetBody.Replace("@CARDS", sb.ToString()));

            Process.Start(new ProcessStartInfo(previewHtml)
            {
                UseShellExecute = true
            });
        }

        private void RefreshModsFolderMenuButton_Click(object sender, EventArgs e)
        {
            LoadMods();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm.Instance.ShowDialog();
        }

        private void BuyMeACoffeeButton_Click(object sender, EventArgs e)
        {
            AboutForm.Instance.OpenUrl(AboutForm.Instance.BuyMeACoffeeUrl);
        }
        #endregion

        #region ## Private
        private void ConfigureComponents()
        {
            BrowserDialog.RootFolder = Environment.SpecialFolder.UserProfile; 

            ConfigureListViews();

            ToggleModsComponents(false);
        }

        private void ToggleModsComponents(bool toggle)
        {
            PreviewImageButton.Enabled = toggle;
            InstallButton.Enabled = toggle;
            UninstallButton.Enabled = toggle;
            SelectAllButton.Enabled = toggle;
            DeselectAllButton.Enabled = toggle;
            OpenFolderButton.Enabled = toggle;
            PreviewImagesButton.Enabled = toggle;
        }

        private void BrowseFolder(TextBox textBox)
        {
            if (BrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            textBox.Text = BrowserDialog.SelectedPath;

            SaveSettings();
        }

        private void LoadData()
        {
            LoadSettings();

            LoadMods();
        }

        private void LoadSettings()
        {
            ModsFolderText.Text = Settings.Default.ModsFolder;

            UserProfileFolderText.Text = Settings.Default.UserProfileFolder;
        }

        private void SaveSettings()
        {
            Settings.Default.UserProfileFolder = ValidateFolder(UserProfileFolderLabel, UserProfileFolderText);
            Settings.Default.ModsFolder = ValidateFolder(ModsFolderLabel, ModsFolderText);

            if (HasErrors())
                return;

            Settings.Default.Save();

            string ValidateFolder(Label label, TextBox textBox)
            {
                DefaultErrorProvider.SetError(label, string.Empty);

                if (!Directory.Exists(textBox.Text))
                {
                    DefaultErrorProvider.SetError(label, "This folder does not exist.");
                }

                return textBox.Text;
            }

            bool HasErrors()
            {
                var controls = new[] { UserProfileFolderLabel, ModsFolderLabel };

                return controls.Any(x => !string.IsNullOrEmpty(DefaultErrorProvider.GetError(x)));
            }
        }

        private void LoadMods()
        {
            if (string.IsNullOrEmpty(ModsFolderText.Text))
                return;

            ModsTreeView.Nodes.Clear();
            _modDirectories.Clear();
            _rawFiles.Clear();
            FileList.Items.Clear();
            ToggleModsComponents(false);

            var rootDirectories = GetDirectories(ModsFolderText.Text);

            var rootNode = new TreeNode("Mods");

            PopulateTreeView(rootNode, rootDirectories);

            ModsTreeView.Nodes.Add(rootNode);

            _rawFiles.AddRange(Directory.GetFiles(ModsFolderText.Text, "*", SearchOption.AllDirectories).Select(x => new FileInfo(x)));
        }

        private void PopulateTreeView(TreeNode parentNode, IEnumerable<DirectoryInfo> parentDirs)
        {
            foreach (var parentDir in parentDirs)
            {
                var childDirs = GetDirectories(parentDir.FullName);

                var childNode = new TreeNode(parentDir.Name) { Tag = parentDir.FullName };

                if (childDirs.Any())
                    PopulateTreeView(childNode, childDirs);

                parentNode.Nodes.Add(childNode);

                _modDirectories.Add(parentDir);
            }
        }

        private void PopulateItemsForSelectedMod(string folder)
        {
            ListViewItem fileItem = default!;
            FileList.Items.Clear();

            _selectedModFiles = _rawFiles.Where(x => x!.Directory!.FullName.StartsWith(folder));

            if (Settings.Default.HideTrayFiles)
                _selectedModFiles = _selectedModFiles.Where(x => Program.FileConfiguration.IsSelectableFile(x));

            if (_selectedModFiles.Count() > 150 && Settings.Default.LimitBigModsFolder)
            {
                var result = DialogResult.Yes;

                var text = "There are a lot of files in this folder. It might take a while to load up, it's harder to manage and it will consume more memory.\n\nYou can disble this warning on the settings.\n\nLoad them all anyway?";

                result = MessageBox.Show(text, "Load Up Time", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                _selectedModFiles = result == DialogResult.Yes ? _selectedModFiles : _selectedModFiles.Take(150);
            }

            foreach (var file in _selectedModFiles.OrderBy(x => x.Extension).ThenBy(x => x.Name))
            {
                fileItem = _fileItems.SingleOrDefault(x => x.Tag.ToString() == file.FullName)!;

                if (fileItem == null)
                {
                    fileItem = new ListViewItem(new[] { file.Name, file.Extension })
                    {
                        ImageIndex = Program.FileConfiguration.GetImageIconIndex(file),
                        Tag = file.FullName,
                        Checked = Program.ModsInfo.IsInstalled(file),
                        ToolTipText = file.Name
                    };
                }

                FileList.Items.Add(fileItem);
            }

            if (_selectedModFiles.Any())
                ToggleModsComponents(true);
            else
                ToggleModsComponents(false);

            FileList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            FileList.Columns[0].Width = FileList.Width - FileList.Columns[1].Width - 22;
        }

        private void ConfigureListViews()
        {
            Program.FileConfiguration.AddImageIcons(FileListImageList);

            FileList.CheckBoxes = true;
            FileList.View = View.Details;
            FileList.MultiSelect = false;
            FileList.Columns.Add(NewHeader("Name", DetailsModsPanel.Width - 95));
            FileList.Columns.Add(NewHeader("Type", 70));
            FileList.SmallImageList = FileListImageList;

            static ColumnHeader NewHeader(string name, int width)
            {
                return new ColumnHeader
                {
                    Name = name,
                    Text = name,
                    Width = width
                };
            }
        }

        private void RefreshSelected()
        {
            foreach (ListViewItem item in FileList.Items)
                item.Checked = Program.ModsInfo.IsInstalled(_selectedModFiles.SingleOrDefault(x => x.FullName == item.Tag.ToString())!);
        }

        private static IEnumerable<DirectoryInfo> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).Select(x => new DirectoryInfo(x));
        }

        private static void OpenInExplorer(string args)
        {
            _ = Process.Start("Explorer.exe", args);
        }
        #endregion
    }
}