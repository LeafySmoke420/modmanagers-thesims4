using App.Win.Forms;
using App.Win.Forms.Common;
using LwdGeeks.ModManagers.TheSims4.App.Win;
using LwdGeeks.ModManagers.TheSims4.App.Win.Extensions;
using LwdGeeks.ModManagers.TheSims4.App.Win.Forms.Common;
using LwdGeeks.ModManagers.TheSims4.App.Win.Managers;
using LwdGeeks.ModManagers.TheSims4.App.Win.Models;
using LwdGeeks.ModManagers.TheSims4.App.Win.Resources;
using System.Diagnostics;
using System.Text;

namespace App.Win
{
    public partial class MainForm : BaseForm
    {
        private readonly AppSettings _appSettings;
        private readonly FileManager _fileManager;
        private readonly List<DirectoryInfo> _modDirectories;
        private readonly List<ListViewItem> _fileItems;
        private readonly List<FileInfo> _rawFiles;

        private IEnumerable<FileInfo> _selectedModFiles;

        public MainForm()
        {
            _appSettings = Program.AppSettings;
            _fileManager = Program.FileManager;
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

            PreviewImageButton.Enabled = file != null && _fileManager.IsImageFile(file);
        }

        private void ModsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            ModsTreeView.SelectedNode = e.Node;
        }

        private void ModsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null || e.Node.Text == "c")
                return;

            var folder = _modDirectories.SingleOrDefault(x => x.FullName == e.Node.Tag.ToString());

            if (folder == null)
                return;

            e.Node.SelectedImageIndex = _fileManager.GetFolderImageIndex();

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
            InstallMods(FileList.CheckedItems.Cast<ListViewItem>().Select(x => new FileInfo(x.Tag.ToString()!)));
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            UninstallMods(FileList.CheckedItems.Cast<ListViewItem>().Select(x => new FileInfo(x.Tag.ToString()!)));
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in FileList.Items)
            {
                if (_fileManager.CanBeInstalled(item.Tag.ToString()!))
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

            if (file == null || !_fileManager.IsImageFile(file))
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

            var files = Directory.EnumerateFiles(selectedFolder!, "*", SearchOption.AllDirectories).Select(x => new FileInfo(x)).Where(x => _fileManager.IsImageFile(x));

            if (!files.Any())
            {
                MessageBoxExt.Information("No images to show on this folder. =/", "No Images");

                return;
            }

            foreach (var file in files)
            {
                sb.AppendLine(AppTemplates.HtmlPreviewCheatSheetCard
                    .Replace("@DIRECTORY", file.DirectoryName!.Replace(selectedFolder, string.Empty))
                    .Replace("@FULLNAME", file.FullName)
                    .Replace("@NAME", file.Name));
            }

            var previewHtml = Path.Combine(_appSettings.AppDataFolder, "previewcheatsheet.html");

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

        private void ResetButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxExt.Confirmation("This will uninstall and remove all the mods from the profile folder.") == DialogResult.No)
                return;

            Cursor = Cursors.WaitCursor;
            Program.FileManager.ResetAndCleanUp(StatusStrip);
            LoadMods();
            Cursor = Cursors.Default;

            MessageBoxExt.Information("All Done. Everything was deleted.", "Succcess");
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
            ModsFolderText.Text = _appSettings.ModsFolder;

            UserProfileFolderText.Text = _appSettings.UserProfileFolder;
        }

        private void SaveSettings()
        {
            _appSettings.UserProfileFolder = ValidateFolder(UserProfileFolderLabel, UserProfileFolderText);
            _appSettings.ModsFolder = ValidateFolder(ModsFolderLabel, ModsFolderText);

            if (HasErrors())
                return;

            _appSettings.Save();

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

            var rootNode = new TreeNode("Root")
            {
                ImageIndex = _fileManager.GetFolderImageIndex()
            };

            PopulateTreeView(rootNode, rootDirectories);

            ModsTreeView.Nodes.Add(rootNode);

            _rawFiles.AddRange(Directory.GetFiles(ModsFolderText.Text, "*", SearchOption.AllDirectories).Select(x => new FileInfo(x)));
        }

        private void PopulateTreeView(TreeNode parentNode, IEnumerable<DirectoryInfo> parentDirs)
        {
            foreach (var parentDir in parentDirs)
            {
                var childDirs = GetDirectories(parentDir.FullName);

                var childNode = new TreeNode(parentDir.Name)
                {
                    Tag = parentDir.FullName,
                    ImageIndex = _fileManager.GetFolderImageIndex()
                };

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

            if (_appSettings.HideTrayFiles)
                _selectedModFiles = _selectedModFiles.Where(x => _fileManager.IsSelectableFile(x));

            if (_selectedModFiles.Count() > 150 && _appSettings.LimitBigModsFolder)
            {
                var messageBoxText = "There are a lot of files in this folder. It might take a while to load up, it's harder to manage and it will consume more memory.\n\nYou can disble this warning on the settings.\n\nLoad them all anyway?";

                _selectedModFiles = MessageBoxExt.Confirmation(messageBoxText) == DialogResult.Yes
                    ? _selectedModFiles
                    : _selectedModFiles.Take(150);
            }

            foreach (var file in _selectedModFiles.OrderBy(x => x.Extension).ThenBy(x => x.Name))
            {
                fileItem = _fileItems.SingleOrDefault(x => x.Tag.ToString() == file.FullName)!;

                if (fileItem == null)
                {
                    fileItem = new ListViewItem(new[] { file.Name, file.Extension })
                    {
                        ImageIndex = _fileManager.GetImageIndexByFileInfo(file),
                        Tag = file.FullName,
                        Checked = Program.FileManager.IsInstalled(file),
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
            _fileManager.AddImageIcons(FileListImageList);
            ModsTreeView.SelectedImageIndex = _fileManager.GetFolderImageIndex();

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
                item.Checked = Program.FileManager.IsInstalled(_selectedModFiles.SingleOrDefault(x => x.FullName == item.Tag.ToString())!);
        }

        private void InstallMods(IEnumerable<FileInfo> files)
        {
            Cursor = Cursors.WaitCursor;

            Program.FileManager.Install(files, StatusStrip);

            Cursor = Cursors.Default;

            if (!_appSettings.SkipSuccessInstallUninstall)
                MessageBoxExt.Information(StatusLabel.Text);
        }

        private void UninstallMods(IEnumerable<FileInfo> files)
        {
            Cursor = Cursors.WaitCursor;

            Program.FileManager.Uninstall(files, StatusStrip);

            RefreshSelected();

            Cursor = Cursors.Default;

            if (!_appSettings.SkipSuccessInstallUninstall)
                MessageBoxExt.Information(StatusLabel.Text);
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