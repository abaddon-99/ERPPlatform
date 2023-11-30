namespace ERP.Domain.Entities.Orders
{
    public abstract class Order
    {
        public int OrderID { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CloseDate { get; set; }

        public decimal TotalAmount { get; private set; }
        public OrderStatus Status { get; set; }
        public string? Comment { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems?.Add(orderItem);
            TotalAmount += orderItem.TotalAmount;
        }

        public void UpdateTotalAmount()
        {
            TotalAmount = OrderItems != null ? OrderItems.Sum(order => order.TotalAmount) : 0;
        }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Closed,
        Cancelled
    }

}

