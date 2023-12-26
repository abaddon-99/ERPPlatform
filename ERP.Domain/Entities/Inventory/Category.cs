namespace ERP.Domain.Entities.Inventory
{
    public class Category
    {
        public int Id { get; set; }

        // Basic Information
        public required string Name { get; set; }
        public string? Description { get; set; }

        // Relationship Navigation Property
        public ICollection<Product>? Products { get; set; }

        // Additional properties and methods specific to Category can be added
    }

}

