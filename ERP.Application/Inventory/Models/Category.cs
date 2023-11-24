using System;
namespace ERP.Inventory.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        // Basic Information
        public required string Name { get; set; }
        public string? Description { get; set; }

        // Relationship Navigation Property
        public ICollection<Product>? Products { get; set; }

        // Additional properties and methods specific to Category can be added
    }

}

