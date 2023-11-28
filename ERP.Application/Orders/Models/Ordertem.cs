using ERP.Application.Inventory.Models;

namespace ERP.Application.Orders.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }

        // Item Information
        public int ProductID { get; set; }
        public required Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get { return Quantity * UnitPrice; } }

        // Relationship Navigation Property
        public int OrderID { get; set; }
        public required Order Order { get; set; }

        // Additional properties and methods specific to OrderItem can be added
    }

}

