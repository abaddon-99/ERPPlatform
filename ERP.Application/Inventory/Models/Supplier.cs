using System;
namespace ERP.Application.Inventory.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        public required string Name { get; set; }
        public string? ContactPerson { get; set; }
        public required string ContactNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }

        public decimal TotalPurchases { get; set; }

        public ICollection<Product>? Products { get; set; }

        public void AddPurchase(decimal amount)
        {
            TotalPurchases += amount;
        }
    }
}