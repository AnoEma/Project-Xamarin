using Xamarin.Forms;

namespace ProjectXamarinApp.Models
{
    public static class Constants
    {
        public readonly static Color BackgroundColor = Color.FromRgb(58, 153, 215);
        public readonly static Color MainTextColor = Color.White;
        public readonly static int LoginIconHeigth = 120;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "<Pending>")]
        public readonly static string LoginUrl = "https://test.com/api/Auth/Login";

        public readonly static string NoInternetText = "No Internet, please reconnect.";
    }
}