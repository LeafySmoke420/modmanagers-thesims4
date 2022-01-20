namespace App.Win.Forms
{
    partial class AboutForm
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
            this.SourcesText = new System.Windows.Forms.TextBox();
            this.SourcesLabel = new System.Windows.Forms.Label();
            this.AppInfoLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.BuyMeACoffeeLabel = new System.Windows.Forms.LinkLabel();
            this.RepoLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // SourcesText
            // 
            this.SourcesText.Location = new System.Drawing.Point(12, 83);
            this.SourcesText.Multiline = true;
            this.SourcesText.Name = "SourcesText";
            this.SourcesText.ReadOnly = true;
            this.SourcesText.Size = new System.Drawing.Size(660, 116);
            this.SourcesText.TabIndex = 0;
            this.SourcesText.Text = "Icons from Flaticon (https://www.flaticon.com)\r\nAuthors: bukeicon, prettycons, Al" +
    "fredo Hernandez, surang, Pixel perfect, kumakamu, Freepik, Octopocto, Chanut-is-" +
    "Industries, Smashicons, Good Ware";
            // 
            // SourcesLabel
            // 
            this.SourcesLabel.AutoSize = true;
            this.SourcesLabel.Location = new System.Drawing.Point(12, 65);
            this.SourcesLabel.Name = "SourcesLabel";
            this.SourcesLabel.Size = new System.Drawing.Size(131, 15);
            this.SourcesLabel.TabIndex = 2;
            this.SourcesLabel.Text = "Sources && Contributors";
            // 
            // AppInfoLabel
            // 
            this.AppInfoLabel.AutoSize = true;
            this.AppInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.AppInfoLabel.Name = "AppInfoLabel";
            this.AppInfoLabel.Size = new System.Drawing.Size(149, 15);
            this.AppInfoLabel.TabIndex = 3;
            this.AppInfoLabel.Text = "The Sims 4 - Mod Manager";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(12, 37);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(103, 15);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Version: 0.0.1-beta";
            // 
            // BuyMeACoffeeLabel
            // 
            this.BuyMeACoffeeLabel.AutoSize = true;
            this.BuyMeACoffeeLabel.Location = new System.Drawing.Point(443, 37);
            this.BuyMeACoffeeLabel.Name = "BuyMeACoffeeLabel";
            this.BuyMeACoffeeLabel.Size = new System.Drawing.Size(229, 15);
            this.BuyMeACoffeeLabel.TabIndex = 7;
            this.BuyMeACoffeeLabel.TabStop = true;
            this.BuyMeACoffeeLabel.Text = "https://www.buymeacoffee.com/lwdgeek";
            this.BuyMeACoffeeLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BuyMeACoffeeLabel_LinkClicked);
            // 
            // RepoLabel
            // 
            this.RepoLabel.AutoSize = true;
            this.RepoLabel.Location = new System.Drawing.Point(369, 9);
            this.RepoLabel.Name = "RepoLabel";
            this.RepoLabel.Size = new System.Drawing.Size(292, 15);
            this.RepoLabel.TabIndex = 8;
            this.RepoLabel.TabStop = true;
            this.RepoLabel.Text = "https://github.com/lwdgeek/modmanagers-thesims4";
            this.RepoLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RepoLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 211);
            this.Controls.Add(this.RepoLabel);
            this.Controls.Add(this.BuyMeACoffeeLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.AppInfoLabel);
            this.Controls.Add(this.SourcesLabel);
            this.Controls.Add(this.SourcesText);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SourcesText;
        private Label SourcesLabel;
        private Label AppInfoLabel;
        private Label VersionLabel;
        private LinkLabel BuyMeACoffeeLabel;
        private LinkLabel RepoLabel;
    }
}