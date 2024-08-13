namespace GuitarApp.Models
{
    internal class Guitar
    {
        public string SerialNumber { get; set; }
        public double Price { get; set; }
        public GuitarSpecs GuitarSpecs { get; set; }

        public Guitar(string srNo, double price, GuitarSpecs guitarSpecs)
        {
            SerialNumber = srNo;
            Price = price;
            GuitarSpecs = guitarSpecs;
        }
    }
}
