namespace TicTacToeFasade.Exceptions
{
    internal class InvalidCellIndexException : Exception
    {
        public InvalidCellIndexException(string message) : base(message) { }
    }
}
