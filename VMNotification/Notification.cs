namespace VMNotification
{
    public struct Notification
    {
        public string Message { get; }
        public string Code { get; }

        public Notification(string message, string code = default)
        {
            Code = code;
            Message = message;
        }
    }
}
