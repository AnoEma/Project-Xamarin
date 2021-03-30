using CoreFoundation;
using System;
using SystemConfiguration;

namespace ProjectXamarinApp.iOS.Data
{
    public class NetworkConnection
    {
        public bool IsConnected { get; set; }

        public void CheckeNetworkConnection()
        {
            InternetStatus();
        }

        public bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = IsNetworkAvailable(out flags);

            if (defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0)) { return false; }
            else if ((flags & NetworkReachabilityFlags.IsWWAN) != 0) { return true; }
            else if (flags == 0) { return false; }

            return true;
        }

        private event EventHandler ReachabilityChanged;
        private void OnChange(NetworkReachabilityFlags flags)
        {
            var ano = ReachabilityChanged;
            if (ano != null)
            {
                ano(null, EventArgs.Empty);
            }
        }

        private NetworkReachability defaultReachability;
        private bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if (defaultReachability == null)
            {
                defaultReachability = new NetworkReachability(new System.Net.IPAddress(0));
                defaultReachability.SetNotification(OnChange);
                defaultReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }

            if (!defaultReachability.TryGetFlags(out flags))
            {
                return false;
            }
            return IsReachablewithoutRequiringConnection(flags);
        }

        private bool IsReachablewithoutRequiringConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if ((flags & NetworkReachabilityFlags.IsWWAN) != 0)
                noConnectionRequired = true;

            return isReachable && noConnectionRequired;
        }
    }
}