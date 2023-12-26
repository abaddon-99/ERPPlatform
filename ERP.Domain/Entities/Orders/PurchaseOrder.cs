using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Domain.Entities.Employees;
using ERP.Domain.Entities.Inventory;
using ERP.Domain.Enums;

namespace ERP.Domain.Entities.Orders
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? CloseDate { get; set; }

        public decimal TotalAmount { get; private set; }
        public OrderStatus Status { get; set; }
        public string? Comment { get; set; }
    
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}