namespace ProductSupplierDb.Exceptions
{
    internal class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string message) : base(message) { }
    }

}
