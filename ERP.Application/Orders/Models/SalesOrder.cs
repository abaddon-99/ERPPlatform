using ERP.Application.Employees.Models;

namespace ERP.Application.Orders.Models;

public class SalesOrder : Order
{
    public int CustomerID { get; set; }
    public required Customer Customer { get; set; }
    public required Employee SalesEmployee { get; set; }
}
