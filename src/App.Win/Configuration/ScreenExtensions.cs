namespace LwdGeeks.ModManagers.TheSims4.App.Win.Configuration
{
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
}