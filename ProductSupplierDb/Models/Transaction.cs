using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSupplierDb.Models
{
    internal class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public override string ToString()
        {
            return $"Transaction ID: {Id}\n" +
                   $"Product ID: {ProductId}\n" +
                   $"Type: {Type}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Date: {Date}\n";
        }
    }


}
