using ERP.Domain.Entities.Inventory;

namespace ERP.Domain.Entities.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get { return Quantity * UnitPrice; } }

        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        
        public int? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
    }
}