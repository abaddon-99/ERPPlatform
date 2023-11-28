namespace ERP.Application.Inventory.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        // Basic Information
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Financial Information
        public decimal CostPrice { get; set; }
        public decimal ProfitMargin
        {
            get { return Price - CostPrice; }
        }

        // Dates
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdated { get; set; }

        // Relationship Navigation Properties
        public int SupplierID { get; set; }
        public required Supplier Supplier { get; set; }

        public int CategoryID { get; set; }
        public required Category Category { get; set; }

        // Methods

        /// <summary>
        /// Updates the stock quantity when a sale occurs.
        /// </summary>
        /// <param name="quantitySold">The quantity sold in the transaction.</param>
        public void UpdateStock(int quantitySold)
        {
            if (quantitySold <= StockQuantity)
            {
                StockQuantity -= quantitySold;
            }
            else
            {
                throw new InvalidOperationException("Insufficient stock available.");
            }

            LastUpdated = DateTime.UtcNow;
        }

        /// <summary>
        /// Calculates the total value of the current stock.
        /// </summary>
        /// <returns>The total value of the current stock.</returns>
        public decimal CalculateStockValue()
        {
            return Price * StockQuantity;
        }

        // Additional properties and methods specific to Product can be added
    }
}

