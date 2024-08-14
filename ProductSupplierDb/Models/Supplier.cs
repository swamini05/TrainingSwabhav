using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSupplierDb.Models
{
    internal class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public override string ToString()
        {
            return $"Supplier ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Contact Info: {ContactInfo}\n";
        }
    }

}
