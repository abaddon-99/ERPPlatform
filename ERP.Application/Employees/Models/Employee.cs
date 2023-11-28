namespace ERP.Application.Employees.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        // Personal Information
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public required string Address { get; set; }

        // Employment Information
        public string? Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        // Relationship Navigation Property
        public int DepartmentID { get; set; }
        public required Department Department { get; set; }

        // Attendance Navigation Property
        public ICollection<Attendance>? Attendances { get; set; }

        // Additional properties and methods specific to Employee can be added
    }

}

