using Android.App;
using Android.Content;
using Android.Net;
using ProjectXamarinApp.Data;
using System;

namespace ProjectXamarinApp.Droid.Data
{
    public class NetworkConnection : INetworkConnection
    {
        public bool IsConnected { get; set; }

#pragma warning disable S1123
        [Obsolete]
#pragma warning restore S1123
        public void CheckeNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;

            IsConnected = (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting);
        }
    }
}