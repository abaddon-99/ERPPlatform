namespace ERP.Domain.Entities.Employees
{
    public class Department
    {
        public int Id { get; set; }

        // Department Information
        public required string Name { get; set; }
        public string? Description { get; set; }

        // Relationship Navigation Property
        public ICollection<Employee>? Employees { get; set; }

        // Additional properties and methods specific to Department can be added
    }

}

