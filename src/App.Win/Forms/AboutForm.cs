using LwdGeeks.ModManagers.TheSims4.App.Win.Forms.Common;
using System.Diagnostics;

namespace App.Win.Forms
{
    public partial class AboutForm : BaseForm
    {
        private static AboutForm _instance;
        private readonly ProcessStartInfo _processStartInfo;

        public AboutForm()
        {
            InitializeComponent();

            ConfigureAbout();

            _processStartInfo = new ProcessStartInfo
            {
                UseShellExecute = true
            };
        }

        public static AboutForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AboutForm();

                return _instance;
            }
        }

        public string BuyMeACoffeeUrl => BuyMeACoffeeLabel.Text;

        public void OpenUrl(string url)
        {
            _processStartInfo.FileName = url;

            Process.Start(_processStartInfo);
        }

        private void RepoLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(RepoLabel.Text);
        }

        private void BuyMeACoffeeLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(BuyMeACoffeeLabel.Text);
        }
    }
}
