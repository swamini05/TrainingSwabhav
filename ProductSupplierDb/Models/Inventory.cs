using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductSupplierDb.Models
{
    internal class Inventory
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Inventory()
        {
            Products = new List<Product>();
            Suppliers = new List<Supplier>();
            Transactions = new List<Transaction>();
        }
        public override string ToString()
        {
            var report = new StringBuilder();

            report.AppendLine($"Inventory Report for {Location} (ID: {Id}):");
            report.AppendLine("======================================================");

            report.AppendLine("Products:");
            report.AppendLine("Product ID\tName\t\tDescription\tQuantity\tPrice");
            foreach (var product in Products)
            {
                report.AppendLine($"{product.Id}\t\t{product.Name}\t\t{product.Description}\t\t{product.Quantity}\t\t{product.Price}");
            }

            report.AppendLine("\nSuppliers:");
            report.AppendLine("Supplier ID\tName\t\tContact");
            foreach (var supplier in Suppliers)
            {
                report.AppendLine($"{supplier.Id}\t\t{supplier.Name}\t{supplier.ContactInfo}");
            }

            report.AppendLine("\nTransactions:");
            report.AppendLine("Transaction ID\tProduct ID\tType\t\tQuantity\tDate");
            foreach (var transaction in Transactions)
            {
                report.AppendLine($"{transaction.Id}\t\t{transaction.ProductId}\t\t{transaction.Type}\t{transaction.Quantity}\t\t{transaction.Date}");
            }

            return report.ToString();
        }
    }
}



