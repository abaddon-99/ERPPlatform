using ERP.Application.Inventory.Models;

namespace ERP.Application.Orders.Models;

public class PurchaseOrder : Order
{
    public int SupplierID { get; set; }
    public required Supplier Customer { get; set; }
}
