namespace ERP.Domain.Entities.Orders
{
    public class Customer
    {
        public int Id { get; set; }

        // Customer Information
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public required string Address { get; set; }

        // Relationship Navigation Property
        public ICollection<SalesOrder>? SalesOrders { get; set; }
    }

}