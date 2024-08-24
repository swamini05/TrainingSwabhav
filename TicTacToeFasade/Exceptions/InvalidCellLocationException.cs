namespace TicTacToeFasade.Exceptions
{
    internal class InvalidCellLocationException : Exception
    {
        public InvalidCellLocationException(string message) : base(message) { }
    }
}
