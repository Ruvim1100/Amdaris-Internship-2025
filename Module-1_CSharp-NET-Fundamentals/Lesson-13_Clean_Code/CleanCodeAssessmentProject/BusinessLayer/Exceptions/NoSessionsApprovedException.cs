namespace BusinessLayer.Exceptions
{
    internal class NoSessionsApprovedException : Exception
    {
        public NoSessionsApprovedException() : base() { }
        public NoSessionsApprovedException(string message)
                : base(message) {}
    }
}
