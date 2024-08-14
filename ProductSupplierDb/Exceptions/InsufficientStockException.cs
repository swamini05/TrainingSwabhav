namespace ProductSupplierDb.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message) : base(message) { }
    }

}
