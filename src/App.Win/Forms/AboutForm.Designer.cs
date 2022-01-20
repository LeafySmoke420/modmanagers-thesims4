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
            this.RepoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SourcesText
            // 
            this.SourcesText.Location = new System.Drawing.Point(12, 83);
            this.SourcesText.Multiline = true;
            this.SourcesText.Name = "SourcesText";
            this.SourcesText.Size = new System.Drawing.Size(660, 316);
            this.SourcesText.TabIndex = 0;
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
            this.VersionLabel.Text = "Version: 1.0.0-beta";
            // 
            // RepoLabel
            // 
            this.RepoLabel.AutoSize = true;
            this.RepoLabel.Location = new System.Drawing.Point(369, 9);
            this.RepoLabel.Name = "RepoLabel";
            this.RepoLabel.Size = new System.Drawing.Size(303, 15);
            this.RepoLabel.TabIndex = 5;
            this.RepoLabel.Text = "https://github.com/meowrelon/thesims4-modmanager";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "https://www.buymeacoffee.com/lwdgeek";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 411);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RepoLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.AppInfoLabel);
            this.Controls.Add(this.SourcesLabel);
            this.Controls.Add(this.SourcesText);
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SourcesText;
        private Label SourcesLabel;
        private Label AppInfoLabel;
        private Label VersionLabel;
        private Label RepoLabel;
        private Label label1;
    }
}