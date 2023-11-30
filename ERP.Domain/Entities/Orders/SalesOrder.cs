using ERP.Domain.Entities.Employees;

namespace ERP.Domain.Entities.Orders
{
    public class SalesOrder : Order
    {
        public int CustomerID { get; set; }
        public required Customer Customer { get; set; }
        public required Employee SalesEmployee { get; set; }
    }
}