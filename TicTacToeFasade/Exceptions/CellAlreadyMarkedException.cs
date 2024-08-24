namespace TicTacToeFasade.Exceptions
{
    internal class CellAlreadyMarkedException : Exception
    {
        public CellAlreadyMarkedException(string message) : base(message) { }
    }

}
