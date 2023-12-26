using ERP.Domain.Entities.Orders;

namespace ERP.Domain.Entities.Employees
{
    public class Employee
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public required string Address { get; set; }

        public string? Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        public ICollection<SalesOrder>? SalesOrders { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }

}

