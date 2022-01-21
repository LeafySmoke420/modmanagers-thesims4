namespace App.Win.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FoldersGroupBox = new System.Windows.Forms.GroupBox();
            this.AppDataFolderText = new System.Windows.Forms.TextBox();
            this.BrowseAppDataFolderButton = new System.Windows.Forms.Button();
            this.AppDataFolderLabel = new System.Windows.Forms.Label();
            this.ModsFolderText = new System.Windows.Forms.TextBox();
            this.UserProfileText = new System.Windows.Forms.TextBox();
            this.BrowseUserProfileFolderButton = new System.Windows.Forms.Button();
            this.BrowseModsFolderButton = new System.Windows.Forms.Button();
            this.ModsFolderLabel = new System.Windows.Forms.Label();
            this.UserProfileLabel = new System.Windows.Forms.Label();
            this.ExtensionsGroupBox = new System.Windows.Forms.GroupBox();
            this.TrayFilesText = new System.Windows.Forms.TextBox();
            this.ImageFilesText = new System.Windows.Forms.TextBox();
            this.ModsFilesText = new System.Windows.Forms.TextBox();
            this.TrayFilesLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ImageFilesLabel = new System.Windows.Forms.Label();
            this.ModsFilesLabel = new System.Windows.Forms.Label();
            this.TogglesGroupBox = new System.Windows.Forms.GroupBox();
            this.LimitBigModsFolderCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DefaultErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.SkipConfirmationInstallUninstallCheckbox = new System.Windows.Forms.CheckBox();
            this.SkipSuccessInstallUninstallCheckbox = new System.Windows.Forms.CheckBox();
            this.FoldersGroupBox.SuspendLayout();
            this.ExtensionsGroupBox.SuspendLayout();
            this.TogglesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // FoldersGroupBox
            // 
            this.FoldersGroupBox.Controls.Add(this.AppDataFolderText);
            this.FoldersGroupBox.Controls.Add(this.BrowseAppDataFolderButton);
            this.FoldersGroupBox.Controls.Add(this.AppDataFolderLabel);
            this.FoldersGroupBox.Controls.Add(this.ModsFolderText);
            this.FoldersGroupBox.Controls.Add(this.UserProfileText);
            this.FoldersGroupBox.Controls.Add(this.BrowseUserProfileFolderButton);
            this.FoldersGroupBox.Controls.Add(this.BrowseModsFolderButton);
            this.FoldersGroupBox.Controls.Add(this.ModsFolderLabel);
            this.FoldersGroupBox.Controls.Add(this.UserProfileLabel);
            this.FoldersGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FoldersGroupBox.Name = "FoldersGroupBox";
            this.FoldersGroupBox.Size = new System.Drawing.Size(560, 160);
            this.FoldersGroupBox.TabIndex = 0;
            this.FoldersGroupBox.TabStop = false;
            this.FoldersGroupBox.Text = "Folders";
            // 
            // AppDataFolderText
            // 
            this.AppDataFolderText.Location = new System.Drawing.Point(6, 126);
            this.AppDataFolderText.Name = "AppDataFolderText";
            this.AppDataFolderText.Size = new System.Drawing.Size(510, 23);
            this.AppDataFolderText.TabIndex = 7;
            // 
            // BrowseAppDataFolderButton
            // 
            this.BrowseAppDataFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseAppDataFolderButton.Location = new System.Drawing.Point(522, 122);
            this.BrowseAppDataFolderButton.Name = "BrowseAppDataFolderButton";
            this.BrowseAppDataFolderButton.Size = new System.Drawing.Size(32, 32);
            this.BrowseAppDataFolderButton.TabIndex = 8;
            this.BrowseAppDataFolderButton.Text = "...";
            this.BrowseAppDataFolderButton.UseVisualStyleBackColor = true;
            this.BrowseAppDataFolderButton.Click += new System.EventHandler(this.BrowseAppDataFolderButton_Click);
            // 
            // AppDataFolderLabel
            // 
            this.AppDataFolderLabel.AutoSize = true;
            this.AppDataFolderLabel.Location = new System.Drawing.Point(6, 108);
            this.AppDataFolderLabel.Name = "AppDataFolderLabel";
            this.AppDataFolderLabel.Size = new System.Drawing.Size(92, 15);
            this.AppDataFolderLabel.TabIndex = 6;
            this.AppDataFolderLabel.Text = "App Data Folder";
            // 
            // ModsFolderText
            // 
            this.ModsFolderText.Location = new System.Drawing.Point(6, 81);
            this.ModsFolderText.Name = "ModsFolderText";
            this.ModsFolderText.Size = new System.Drawing.Size(510, 23);
            this.ModsFolderText.TabIndex = 4;
            // 
            // UserProfileText
            // 
            this.UserProfileText.Location = new System.Drawing.Point(6, 37);
            this.UserProfileText.Name = "UserProfileText";
            this.UserProfileText.Size = new System.Drawing.Size(510, 23);
            this.UserProfileText.TabIndex = 1;
            // 
            // BrowseUserProfileFolderButton
            // 
            this.BrowseUserProfileFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseUserProfileFolderButton.Location = new System.Drawing.Point(522, 33);
            this.BrowseUserProfileFolderButton.Name = "BrowseUserProfileFolderButton";
            this.BrowseUserProfileFolderButton.Size = new System.Drawing.Size(32, 32);
            this.BrowseUserProfileFolderButton.TabIndex = 2;
            this.BrowseUserProfileFolderButton.Text = "...";
            this.BrowseUserProfileFolderButton.UseVisualStyleBackColor = true;
            this.BrowseUserProfileFolderButton.Click += new System.EventHandler(this.BrowseUserProfileFolderButton_Click);
            // 
            // BrowseModsFolderButton
            // 
            this.BrowseModsFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseModsFolderButton.Location = new System.Drawing.Point(522, 77);
            this.BrowseModsFolderButton.Name = "BrowseModsFolderButton";
            this.BrowseModsFolderButton.Size = new System.Drawing.Size(32, 32);
            this.BrowseModsFolderButton.TabIndex = 5;
            this.BrowseModsFolderButton.Text = "...";
            this.BrowseModsFolderButton.UseVisualStyleBackColor = true;
            this.BrowseModsFolderButton.Click += new System.EventHandler(this.BrowseModsFolderButton_Click);
            // 
            // ModsFolderLabel
            // 
            this.ModsFolderLabel.AutoSize = true;
            this.ModsFolderLabel.Location = new System.Drawing.Point(6, 63);
            this.ModsFolderLabel.Name = "ModsFolderLabel";
            this.ModsFolderLabel.Size = new System.Drawing.Size(73, 15);
            this.ModsFolderLabel.TabIndex = 3;
            this.ModsFolderLabel.Text = "Mods Folder";
            // 
            // UserProfileLabel
            // 
            this.UserProfileLabel.AutoSize = true;
            this.UserProfileLabel.Location = new System.Drawing.Point(6, 19);
            this.UserProfileLabel.Name = "UserProfileLabel";
            this.UserProfileLabel.Size = new System.Drawing.Size(103, 15);
            this.UserProfileLabel.TabIndex = 0;
            this.UserProfileLabel.Text = "User Profile Folder";
            // 
            // ExtensionsGroupBox
            // 
            this.ExtensionsGroupBox.Controls.Add(this.TrayFilesText);
            this.ExtensionsGroupBox.Controls.Add(this.ImageFilesText);
            this.ExtensionsGroupBox.Controls.Add(this.ModsFilesText);
            this.ExtensionsGroupBox.Controls.Add(this.TrayFilesLabel);
            this.ExtensionsGroupBox.Controls.Add(this.button2);
            this.ExtensionsGroupBox.Controls.Add(this.button3);
            this.ExtensionsGroupBox.Controls.Add(this.ImageFilesLabel);
            this.ExtensionsGroupBox.Controls.Add(this.ModsFilesLabel);
            this.ExtensionsGroupBox.Location = new System.Drawing.Point(12, 178);
            this.ExtensionsGroupBox.Name = "ExtensionsGroupBox";
            this.ExtensionsGroupBox.Size = new System.Drawing.Size(560, 159);
            this.ExtensionsGroupBox.TabIndex = 1;
            this.ExtensionsGroupBox.TabStop = false;
            this.ExtensionsGroupBox.Text = "Extensions";
            // 
            // TrayFilesText
            // 
            this.TrayFilesText.Location = new System.Drawing.Point(6, 125);
            this.TrayFilesText.Name = "TrayFilesText";
            this.TrayFilesText.Size = new System.Drawing.Size(548, 23);
            this.TrayFilesText.TabIndex = 5;
            // 
            // ImageFilesText
            // 
            this.ImageFilesText.Location = new System.Drawing.Point(6, 81);
            this.ImageFilesText.Name = "ImageFilesText";
            this.ImageFilesText.Size = new System.Drawing.Size(548, 23);
            this.ImageFilesText.TabIndex = 3;
            // 
            // ModsFilesText
            // 
            this.ModsFilesText.Location = new System.Drawing.Point(6, 37);
            this.ModsFilesText.Name = "ModsFilesText";
            this.ModsFilesText.Size = new System.Drawing.Size(548, 23);
            this.ModsFilesText.TabIndex = 1;
            // 
            // TrayFilesLabel
            // 
            this.TrayFilesLabel.AutoSize = true;
            this.TrayFilesLabel.Location = new System.Drawing.Point(6, 107);
            this.TrayFilesLabel.Name = "TrayFilesLabel";
            this.TrayFilesLabel.Size = new System.Drawing.Size(54, 15);
            this.TrayFilesLabel.TabIndex = 4;
            this.TrayFilesLabel.Text = "Tray Files";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(882, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 11;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(882, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 10;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ImageFilesLabel
            // 
            this.ImageFilesLabel.AutoSize = true;
            this.ImageFilesLabel.Location = new System.Drawing.Point(6, 63);
            this.ImageFilesLabel.Name = "ImageFilesLabel";
            this.ImageFilesLabel.Size = new System.Drawing.Size(66, 15);
            this.ImageFilesLabel.TabIndex = 2;
            this.ImageFilesLabel.Text = "Image Files";
            // 
            // ModsFilesLabel
            // 
            this.ModsFilesLabel.AutoSize = true;
            this.ModsFilesLabel.Location = new System.Drawing.Point(6, 19);
            this.ModsFilesLabel.Name = "ModsFilesLabel";
            this.ModsFilesLabel.Size = new System.Drawing.Size(58, 15);
            this.ModsFilesLabel.TabIndex = 0;
            this.ModsFilesLabel.Text = "Mod Files";
            // 
            // TogglesGroupBox
            // 
            this.TogglesGroupBox.Controls.Add(this.SkipSuccessInstallUninstallCheckbox);
            this.TogglesGroupBox.Controls.Add(this.SkipConfirmationInstallUninstallCheckbox);
            this.TogglesGroupBox.Controls.Add(this.LimitBigModsFolderCheckbox);
            this.TogglesGroupBox.Location = new System.Drawing.Point(12, 343);
            this.TogglesGroupBox.Name = "TogglesGroupBox";
            this.TogglesGroupBox.Size = new System.Drawing.Size(560, 84);
            this.TogglesGroupBox.TabIndex = 2;
            this.TogglesGroupBox.TabStop = false;
            this.TogglesGroupBox.Text = "Toggles";
            // 
            // LimitBigModsFolderCheckbox
            // 
            this.LimitBigModsFolderCheckbox.AutoSize = true;
            this.LimitBigModsFolderCheckbox.Location = new System.Drawing.Point(209, 20);
            this.LimitBigModsFolderCheckbox.Name = "LimitBigModsFolderCheckbox";
            this.LimitBigModsFolderCheckbox.Size = new System.Drawing.Size(142, 19);
            this.LimitBigModsFolderCheckbox.TabIndex = 0;
            this.LimitBigModsFolderCheckbox.Text = "Limit Big Mods Folder";
            this.LimitBigModsFolderCheckbox.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.Save_24;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveButton.Location = new System.Drawing.Point(372, 433);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(97, 41);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // BrowserDialog
            // 
            this.BrowserDialog.RootFolder = System.Environment.SpecialFolder.UserProfile;
            // 
            // DefaultErrorProvider
            // 
            this.DefaultErrorProvider.ContainerControl = this;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::LwdGeeks.ModManagers.TheSims4.App.Win.Resources.AppImages.Cancel_24;
            this.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseButton.Location = new System.Drawing.Point(475, 433);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(97, 41);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SkipConfirmationInstallUninstallCheckbox
            // 
            this.SkipConfirmationInstallUninstallCheckbox.AutoSize = true;
            this.SkipConfirmationInstallUninstallCheckbox.Location = new System.Drawing.Point(40, 45);
            this.SkipConfirmationInstallUninstallCheckbox.Name = "SkipConfirmationInstallUninstallCheckbox";
            this.SkipConfirmationInstallUninstallCheckbox.Size = new System.Drawing.Size(225, 19);
            this.SkipConfirmationInstallUninstallCheckbox.TabIndex = 1;
            this.SkipConfirmationInstallUninstallCheckbox.Text = "Skip Confirmation for Install/Uninstall";
            this.SkipConfirmationInstallUninstallCheckbox.UseVisualStyleBackColor = true;
            // 
            // SkipSuccessInstallUninstallCheckbox
            // 
            this.SkipSuccessInstallUninstallCheckbox.AutoSize = true;
            this.SkipSuccessInstallUninstallCheckbox.Location = new System.Drawing.Point(271, 45);
            this.SkipSuccessInstallUninstallCheckbox.Name = "SkipSuccessInstallUninstallCheckbox";
            this.SkipSuccessInstallUninstallCheckbox.Size = new System.Drawing.Size(249, 19);
            this.SkipSuccessInstallUninstallCheckbox.TabIndex = 2;
            this.SkipSuccessInstallUninstallCheckbox.Text = "Skip Success Messages for Install/Uninstall";
            this.SkipSuccessInstallUninstallCheckbox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 486);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TogglesGroupBox);
            this.Controls.Add(this.FoldersGroupBox);
            this.Controls.Add(this.ExtensionsGroupBox);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FoldersGroupBox.ResumeLayout(false);
            this.FoldersGroupBox.PerformLayout();
            this.ExtensionsGroupBox.ResumeLayout(false);
            this.ExtensionsGroupBox.PerformLayout();
            this.TogglesGroupBox.ResumeLayout(false);
            this.TogglesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox FoldersGroupBox;
        private Label ModsFolderLabel;
        private TextBox ModsFolderText;
        private Label UserProfileLabel;
        private TextBox UserProfileText;
        private Button BrowseUserProfileFolderButton;
        private Button BrowseModsFolderButton;
        private GroupBox ExtensionsGroupBox;
        private Label TrayFilesLabel;
        private TextBox TrayFilesText;
        private Button button2;
        private Button button3;
        private Label ImageFilesLabel;
        private TextBox ImageFilesText;
        private Label ModsFilesLabel;
        private TextBox ModsFilesText;
        private GroupBox TogglesGroupBox;
        private CheckBox LimitBigModsFolderCheckbox;
        private Button SaveButton;
        private FolderBrowserDialog BrowserDialog;
        private ErrorProvider DefaultErrorProvider;
        private TextBox AppDataFolderText;
        private Button BrowseAppDataFolderButton;
        private Label AppDataFolderLabel;
        private Button CloseButton;
        private CheckBox SkipSuccessInstallUninstallCheckbox;
        private CheckBox SkipConfirmationInstallUninstallCheckbox;
    }
}