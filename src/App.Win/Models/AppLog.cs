namespace LwdGeeks.ModManagers.TheSims4.App.Win.Models
{
    public class AppLog
    {
        public string Reference { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }

        public static AppLog Create(string message, Exception ex)
        {
            return new()
            {
                Reference = DateTime.Now.ToString("yymmddhhmmssfff"),
                Message = message,
                ExceptionMessage = ex.Message,
                InnerExceptionMessage = ex.InnerException?.Message!
            };
        }
    }
}