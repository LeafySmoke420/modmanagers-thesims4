using App.Win.Resources;

namespace App.Win.Forms.Common;

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
        StartPosition = FormStartPosition.CenterScreen;
        Size = Screen.PrimaryScreen.Resize();
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        ShowInTaskbar = true;
    }

    protected void DefaultDialog()
    {
        Default();

        MinimizeBox = false;
    }

    protected void ConfigureMain()
    {
        DefaultDialog();

        ShowInTaskbar = true;
        MinimizeBox = true;

        ResizeWindow(0.5, 0.75);
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


public static class ScreenExtensions
{
    public static Size Resize(this Screen screen, double size = 0.5)
    {
        return new Size(Floor(screen.Bounds.Width), Floor(screen.Bounds.Height));

        int Floor(int value) => (int)Math.Floor(value * size);
    }

    public static Size Resize(this Screen screen, double width, double height)
    {
        return new Size(
            (int)Math.Floor(screen.Bounds.Width * width),
            (int)Math.Floor(screen.Bounds.Height * height));
    }

    public static Size Resize(this Screen screen, int width, int height)
    {
        width = SetWithinLimitsOf(screen.Bounds.Width, width);
        height = SetWithinLimitsOf(screen.Bounds.Height, height);

        return new Size(width, height);

        static int SetWithinLimitsOf(int referenceValue, int value)
        {
            return value > referenceValue || value < 0 ? 500 : value;
        }
    }
}