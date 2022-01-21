namespace LwdGeeks.ModManagers.TheSims4.App.Win.Extensions
{
    public static class MessageBoxExt
    {
        public static DialogResult Confirmation(string message, string title = "Confirmation", MessageBoxButtons buttons = MessageBoxButtons.YesNo)
        {
            return MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
        }

        internal static DialogResult Information(string message, string title = "Information", MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            return MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
        }
    }
}