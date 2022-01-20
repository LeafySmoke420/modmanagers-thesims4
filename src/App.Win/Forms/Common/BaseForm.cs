using LwdGeeks.ModManagers.TheSims4.App.Win.Configuration;
using LwdGeeks.ModManagers.TheSims4.App.Win.Resources;

namespace LwdGeeks.ModManagers.TheSims4.App.Win.Forms.Common;

public class BaseForm : Form
{
    private readonly string _defaultText;

    public BaseForm()
    {
        _defaultText = "The Sims 4 - Mod Manager";
    }

    protected void Default()
    {
        Text = _defaultText;
        Icon = AppIcons.Icon;
        Size = Screen.PrimaryScreen.Resize();
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = true;
        ShowInTaskbar = true;
    }

    protected void DefaultDialog()
    {
        Default();

        StartPosition = FormStartPosition.CenterParent;
        MinimizeBox = false;
        ShowInTaskbar = false;
    }

    protected void ConfigureMain()
    {
        Default();

        ResizeWindow(0.5, 0.75);
    }

    protected void ConfigureAbout()
    {
        DefaultDialog();

        ResizeWindow(700, 250);
    }

    protected void ConfigurePreviewImage()
    {
        Default();
    }

    protected void ConfigureSettings()
    {
        DefaultDialog();

        UpdateText("Application Settings");

        ResizeWindow(600, 480);
    }

    public void ResizeWindow(int width, int height)
    {
        Size = Screen.PrimaryScreen.Resize(width, height);
    }

    public void ResizeWindow(double width, double height)
    {
        Size = Screen.PrimaryScreen.Resize(width, height);
    }

    public void UpdateText(string text)
    {
        Text = text;
    }
}
