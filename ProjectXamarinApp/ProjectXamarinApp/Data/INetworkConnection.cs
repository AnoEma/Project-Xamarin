namespace ProjectXamarinApp.Data
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckeNetworkConnection();
    }
}