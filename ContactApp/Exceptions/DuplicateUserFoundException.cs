namespace ContactApp.Exceptions
{
    internal class DuplicateUserFoundException : Exception
    {
        public DuplicateUserFoundException(string message) : base(message) { }
    }
}
