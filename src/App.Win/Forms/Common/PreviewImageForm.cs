namespace App.Win.Forms.Common
{
    public partial class PreviewImageForm : BaseForm
    {
        private static PreviewImageForm _instance = default!;

        public PreviewImageForm()
        {
            InitializeComponent();
        }

        public static PreviewImageForm Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PreviewImageForm();

                return _instance;
            }
        }

        public void UpdatePicture(string picture)
        {
            Picture.Image = Image.FromFile(picture);
        }

        private void PreviewImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();

            e.Cancel = true;

            Hide();
        }
    }
}
