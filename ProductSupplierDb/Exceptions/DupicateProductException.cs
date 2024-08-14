namespace ProductSupplierDb.Exceptions
{
    internal class DuplicateProductException : Exception
    {
        public DuplicateProductException(string message) : base(message) { }
    }

}
