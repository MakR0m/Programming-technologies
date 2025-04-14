namespace SOLID.DIP.UserNotifier
{
    internal interface INotifier
    {
        void Send(string user, string message);
    }
}