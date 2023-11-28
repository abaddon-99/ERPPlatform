using System;
namespace ERP.Application.Employees.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        // Department Information
        public required string Name { get; set; }
        public string? Description { get; set; }

        // Relationship Navigation Property
        public ICollection<Employee>? Employees { get; set; }

        // Additional properties and methods specific to Department can be added
    }

}

