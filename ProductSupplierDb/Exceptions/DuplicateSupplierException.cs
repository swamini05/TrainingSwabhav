namespace ProductSupplierDb.Exceptions
{
    internal class DuplicateSupplierException : Exception
    {
        public DuplicateSupplierException(string message) : base(message) { }
    }

}
