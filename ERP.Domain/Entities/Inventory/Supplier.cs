using ERP.Domain.Entities.Orders;

namespace ERP.Domain.Entities.Inventory
{
    public class Supplier
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public string? ContactPerson { get; set; }
        public required string ContactNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }

        public decimal TotalPurchases { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }

        public void AddPurchase(decimal amount)
        {
            TotalPurchases += amount;
        }
    }
}