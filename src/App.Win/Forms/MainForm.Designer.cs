namespace App.Win
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BuyMeACoffeeButton = new System.Windows.Forms.PictureBox();
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshModsFolderMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingsMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.DetailsPanel = new System.Windows.Forms.Panel();
            this.DetailsModsPanel = new System.Windows.Forms.Panel();
            this.FileList = new System.Windows.Forms.ListView();
            this.FileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PreviewImageButton = new System.Windows.Forms.ToolStripMenuItem();
            this.FileListImageList = new System.Windows.Forms.ImageList(this.components);
            this.DetailsActionPanel = new System.Windows.Forms.Panel();
            this.PreviewImagesButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.DeselectAllButton = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.UninstallButton = new System.Windows.Forms.Button();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.ModsPanel = new System.Windows.Forms.Panel();
            this.ModsTreeView = new System.Windows.Forms.TreeView();
            this.BrowseUserProfileFolder = new System.Windows.Forms.Button();
            this.BrowseModsFolder = new System.Windows.Forms.Button();
            this.ModsFolderText = new System.Windows.Forms.TextBox();
            this.ModsFolderLabel = new System.Windows.Forms.Label();
            this.UserProfileFolderText = new System.Windows.Forms.TextBox();
            this.UserProfileFolderLabel = new System.Windows.Forms.Label();
            this.BrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DefaultErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyMeACoffeeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.DetailsPanel.SuspendLayout();
            this.DetailsModsPanel.SuspendLayout();
            this.FileContextMenu.SuspendLayout();
            this.DetailsActionPanel.SuspendLayout();
            this.ModsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.BuyMeACoffeeButton);
            this.TopPanel.Controls.Add(this.LogoPicture);
            this.TopPanel.Controls.Add(this.MenuStrip);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 143);
            this.TopPanel.TabIndex = 1;
            // 
            // BuyMeACoffeeButton
            // 
            this.BuyMeACoffeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyMeACoffeeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuyMeACoffeeButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.BuyMeACoffee_24;
            this.BuyMeACoffeeButton.Location = new System.Drawing.Point(768, 30);
            this.BuyMeACoffeeButton.Name = "BuyMeACoffeeButton";
            this.BuyMeACoffeeButton.Size = new System.Drawing.Size(24, 35);
            this.BuyMeACoffeeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.BuyMeACoffeeButton.TabIndex = 3;
            this.BuyMeACoffeeButton.TabStop = false;
            this.ToolTip.SetToolTip(this.BuyMeACoffeeButton, "Buy me a coffee!");
            this.BuyMeACoffeeButton.Click += new System.EventHandler(this.BuyMeACoffeeButton_Click);
            // 
            // LogoPicture
            // 
            this.LogoPicture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogoPicture.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.Logo_TheSims4;
            this.LogoPicture.Location = new System.Drawing.Point(265, 27);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(270, 110);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPicture.TabIndex = 1;
            this.LogoPicture.TabStop = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuButton,
            this.HelpMenuButton});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileMenuButton
            // 
            this.FileMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshModsFolderMenuButton,
            this.FileSeparator1,
            this.SettingsMenuButton});
            this.FileMenuButton.Name = "FileMenuButton";
            this.FileMenuButton.Size = new System.Drawing.Size(37, 20);
            this.FileMenuButton.Text = "&File";
            // 
            // RefreshModsFolderMenuButton
            // 
            this.RefreshModsFolderMenuButton.Name = "RefreshModsFolderMenuButton";
            this.RefreshModsFolderMenuButton.Size = new System.Drawing.Size(182, 22);
            this.RefreshModsFolderMenuButton.Text = "&Refresh Mods Folder";
            this.RefreshModsFolderMenuButton.Click += new System.EventHandler(this.RefreshModsFolderMenuButton_Click);
            // 
            // FileSeparator1
            // 
            this.FileSeparator1.Name = "FileSeparator1";
            this.FileSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // SettingsMenuButton
            // 
            this.SettingsMenuButton.Name = "SettingsMenuButton";
            this.SettingsMenuButton.Size = new System.Drawing.Size(182, 22);
            this.SettingsMenuButton.Text = "&Settings";
            this.SettingsMenuButton.Click += new System.EventHandler(this.SettingsMenuButton_Click);
            // 
            // HelpMenuButton
            // 
            this.HelpMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutButton});
            this.HelpMenuButton.Name = "HelpMenuButton";
            this.HelpMenuButton.Size = new System.Drawing.Size(44, 20);
            this.HelpMenuButton.Text = "&Help";
            // 
            // AboutButton
            // 
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(107, 22);
            this.AboutButton.Text = "&About";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.DetailsPanel);
            this.ContentPanel.Controls.Add(this.ModsPanel);
            this.ContentPanel.Controls.Add(this.BrowseUserProfileFolder);
            this.ContentPanel.Controls.Add(this.BrowseModsFolder);
            this.ContentPanel.Controls.Add(this.ModsFolderText);
            this.ContentPanel.Controls.Add(this.ModsFolderLabel);
            this.ContentPanel.Controls.Add(this.UserProfileFolderText);
            this.ContentPanel.Controls.Add(this.UserProfileFolderLabel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 143);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(800, 585);
            this.ContentPanel.TabIndex = 2;
            // 
            // DetailsPanel
            // 
            this.DetailsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsPanel.Controls.Add(this.DetailsModsPanel);
            this.DetailsPanel.Controls.Add(this.DetailsActionPanel);
            this.DetailsPanel.Location = new System.Drawing.Point(405, 104);
            this.DetailsPanel.Name = "DetailsPanel";
            this.DetailsPanel.Size = new System.Drawing.Size(383, 469);
            this.DetailsPanel.TabIndex = 17;
            // 
            // DetailsModsPanel
            // 
            this.DetailsModsPanel.Controls.Add(this.FileList);
            this.DetailsModsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsModsPanel.Location = new System.Drawing.Point(0, 38);
            this.DetailsModsPanel.Name = "DetailsModsPanel";
            this.DetailsModsPanel.Size = new System.Drawing.Size(383, 431);
            this.DetailsModsPanel.TabIndex = 3;
            // 
            // FileList
            // 
            this.FileList.ContextMenuStrip = this.FileContextMenu;
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.GroupImageList = this.FileListImageList;
            this.FileList.Location = new System.Drawing.Point(0, 0);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(383, 431);
            this.FileList.TabIndex = 14;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileList_MouseClick);
            // 
            // FileContextMenu
            // 
            this.FileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreviewImageButton});
            this.FileContextMenu.Name = "FileContextMenu";
            this.FileContextMenu.Size = new System.Drawing.Size(152, 26);
            // 
            // PreviewImageButton
            // 
            this.PreviewImageButton.Name = "PreviewImageButton";
            this.PreviewImageButton.Size = new System.Drawing.Size(151, 22);
            this.PreviewImageButton.Text = "Preview Image";
            this.PreviewImageButton.Click += new System.EventHandler(this.PreviewImageButton_Click);
            // 
            // FileListImageList
            // 
            this.FileListImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.FileListImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.FileListImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DetailsActionPanel
            // 
            this.DetailsActionPanel.Controls.Add(this.PreviewImagesButton);
            this.DetailsActionPanel.Controls.Add(this.InstallButton);
            this.DetailsActionPanel.Controls.Add(this.DeselectAllButton);
            this.DetailsActionPanel.Controls.Add(this.SelectAllButton);
            this.DetailsActionPanel.Controls.Add(this.UninstallButton);
            this.DetailsActionPanel.Controls.Add(this.OpenFolderButton);
            this.DetailsActionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DetailsActionPanel.Location = new System.Drawing.Point(0, 0);
            this.DetailsActionPanel.Name = "DetailsActionPanel";
            this.DetailsActionPanel.Size = new System.Drawing.Size(383, 38);
            this.DetailsActionPanel.TabIndex = 0;
            // 
            // PreviewImagesButton
            // 
            this.PreviewImagesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewImagesButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.HtmlImage_24;
            this.PreviewImagesButton.Location = new System.Drawing.Point(348, 3);
            this.PreviewImagesButton.Name = "PreviewImagesButton";
            this.PreviewImagesButton.Size = new System.Drawing.Size(32, 32);
            this.PreviewImagesButton.TabIndex = 13;
            this.ToolTip.SetToolTip(this.PreviewImagesButton, "See all images in a preview html");
            this.PreviewImagesButton.UseVisualStyleBackColor = true;
            this.PreviewImagesButton.Click += new System.EventHandler(this.PreviewImagesButton_Click);
            // 
            // InstallButton
            // 
            this.InstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.Install_24;
            this.InstallButton.Location = new System.Drawing.Point(272, 3);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(32, 32);
            this.InstallButton.TabIndex = 11;
            this.ToolTip.SetToolTip(this.InstallButton, "Install selected mods");
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // DeselectAllButton
            // 
            this.DeselectAllButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.CancelList_24;
            this.DeselectAllButton.Location = new System.Drawing.Point(41, 3);
            this.DeselectAllButton.Name = "DeselectAllButton";
            this.DeselectAllButton.Size = new System.Drawing.Size(32, 32);
            this.DeselectAllButton.TabIndex = 9;
            this.ToolTip.SetToolTip(this.DeselectAllButton, "Deselect all");
            this.DeselectAllButton.UseVisualStyleBackColor = true;
            this.DeselectAllButton.Click += new System.EventHandler(this.DeselectAllButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.CheckList_24;
            this.SelectAllButton.Location = new System.Drawing.Point(3, 3);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(32, 32);
            this.SelectAllButton.TabIndex = 8;
            this.ToolTip.SetToolTip(this.SelectAllButton, "Select all");
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // UninstallButton
            // 
            this.UninstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UninstallButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.Uninstall_24;
            this.UninstallButton.Location = new System.Drawing.Point(310, 3);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(32, 32);
            this.UninstallButton.TabIndex = 12;
            this.ToolTip.SetToolTip(this.UninstallButton, "Uninstall selected mods");
            this.UninstallButton.UseVisualStyleBackColor = true;
            this.UninstallButton.Click += new System.EventHandler(this.UninstallButton_Click);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.OpenFolder_24;
            this.OpenFolderButton.Location = new System.Drawing.Point(79, 3);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(32, 32);
            this.OpenFolderButton.TabIndex = 10;
            this.ToolTip.SetToolTip(this.OpenFolderButton, "Open current folder");
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // ModsPanel
            // 
            this.ModsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ModsPanel.Controls.Add(this.ModsTreeView);
            this.ModsPanel.Location = new System.Drawing.Point(12, 104);
            this.ModsPanel.Name = "ModsPanel";
            this.ModsPanel.Size = new System.Drawing.Size(387, 469);
            this.ModsPanel.TabIndex = 16;
            // 
            // ModsTreeView
            // 
            this.ModsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModsTreeView.Location = new System.Drawing.Point(0, 0);
            this.ModsTreeView.Name = "ModsTreeView";
            this.ModsTreeView.Size = new System.Drawing.Size(387, 469);
            this.ModsTreeView.TabIndex = 7;
            this.ModsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ModsTreeView_AfterSelect);
            // 
            // BrowseUserProfileFolder
            // 
            this.BrowseUserProfileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseUserProfileFolder.Location = new System.Drawing.Point(756, 26);
            this.BrowseUserProfileFolder.Name = "BrowseUserProfileFolder";
            this.BrowseUserProfileFolder.Size = new System.Drawing.Size(32, 32);
            this.BrowseUserProfileFolder.TabIndex = 3;
            this.BrowseUserProfileFolder.Text = "...";
            this.BrowseUserProfileFolder.UseVisualStyleBackColor = true;
            this.BrowseUserProfileFolder.Click += new System.EventHandler(this.BrowseUserProfileFolder_Click);
            // 
            // BrowseModsFolder
            // 
            this.BrowseModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseModsFolder.Location = new System.Drawing.Point(756, 71);
            this.BrowseModsFolder.Name = "BrowseModsFolder";
            this.BrowseModsFolder.Size = new System.Drawing.Size(32, 32);
            this.BrowseModsFolder.TabIndex = 6;
            this.BrowseModsFolder.Text = "...";
            this.BrowseModsFolder.UseVisualStyleBackColor = true;
            this.BrowseModsFolder.Click += new System.EventHandler(this.BrowseModsFolder_Click);
            // 
            // ModsFolderText
            // 
            this.ModsFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModsFolderText.Location = new System.Drawing.Point(12, 75);
            this.ModsFolderText.Name = "ModsFolderText";
            this.ModsFolderText.Size = new System.Drawing.Size(738, 23);
            this.ModsFolderText.TabIndex = 5;
            // 
            // ModsFolderLabel
            // 
            this.ModsFolderLabel.AutoSize = true;
            this.ModsFolderLabel.Location = new System.Drawing.Point(12, 57);
            this.ModsFolderLabel.Name = "ModsFolderLabel";
            this.ModsFolderLabel.Size = new System.Drawing.Size(73, 15);
            this.ModsFolderLabel.TabIndex = 4;
            this.ModsFolderLabel.Text = "Mods Folder";
            // 
            // UserProfileFolderText
            // 
            this.UserProfileFolderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserProfileFolderText.Location = new System.Drawing.Point(12, 31);
            this.UserProfileFolderText.Name = "UserProfileFolderText";
            this.UserProfileFolderText.Size = new System.Drawing.Size(738, 23);
            this.UserProfileFolderText.TabIndex = 2;
            // 
            // UserProfileFolderLabel
            // 
            this.UserProfileFolderLabel.AutoSize = true;
            this.UserProfileFolderLabel.Location = new System.Drawing.Point(12, 13);
            this.UserProfileFolderLabel.Name = "UserProfileFolderLabel";
            this.UserProfileFolderLabel.Size = new System.Drawing.Size(103, 15);
            this.UserProfileFolderLabel.TabIndex = 1;
            this.UserProfileFolderLabel.Text = "User Profile Folder";
            // 
            // DefaultErrorProvider
            // 
            this.DefaultErrorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 728);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.TopPanel);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Text";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuyMeACoffeeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.ContentPanel.PerformLayout();
            this.DetailsPanel.ResumeLayout(false);
            this.DetailsModsPanel.ResumeLayout(false);
            this.FileContextMenu.ResumeLayout(false);
            this.DetailsActionPanel.ResumeLayout(false);
            this.ModsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DefaultErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TopPanel;
        private PictureBox LogoPicture;
        private Panel ContentPanel;
        private Button BrowseUserProfileFolder;
        private Button BrowseModsFolder;
        private TextBox ModsFolderText;
        private Label ModsFolderLabel;
        private TextBox UserProfileFolderText;
        private Label UserProfileFolderLabel;
        private FolderBrowserDialog BrowserDialog;
        private ImageList FileListImageList;
        private Button SelectAllButton;
        private Button DeselectAllButton;
        private Button OpenFolderButton;
        private Button InstallButton;
        private Button UninstallButton;
        private Panel DetailsPanel;
        private Panel DetailsModsPanel;
        private ListView FileList;
        private Panel DetailsActionPanel;
        private Panel ModsPanel;
        private TreeView ModsTreeView;
        private ContextMenuStrip FileContextMenu;
        private ToolStripMenuItem PreviewImageButton;
        private MenuStrip MenuStrip;
        private Button PreviewImagesButton;
        private ErrorProvider DefaultErrorProvider;
        private ToolStripMenuItem FileMenuButton;
        private ToolStripMenuItem RefreshModsFolderMenuButton;
        private ToolStripSeparator FileSeparator1;
        private ToolStripMenuItem SettingsMenuButton;
        private ToolTip ToolTip;
        private ToolStripMenuItem HelpMenuButton;
        private ToolStripMenuItem AboutButton;
        private PictureBox BuyMeACoffeeButton;
    }
}