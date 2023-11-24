using System;
namespace ERP.Order.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        // Order Information
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public required Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }

        // Relationship Navigation Property
        public ICollection<OrderItem>? OrderItems { get; set; }

        // Methods
        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems?.Add(orderItem);
            TotalAmount += orderItem.TotalAmount;
        }

        // Additional properties and methods specific to Order can be added
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }

}

