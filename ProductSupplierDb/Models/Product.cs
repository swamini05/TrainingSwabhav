using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSupplierDb.Models
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public override string ToString()
        {
            return $"Product ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Description: {Description}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Price: {Price}\n";
        }
    }


}
