using ERP.Domain.Entities.Inventory;

namespace ERP.Domain.Entities.Orders
{
    public class PurchaseOrder : Order
    {
        public int SupplierID { get; set; }
        public required Supplier Customer { get; set; }
    }
}