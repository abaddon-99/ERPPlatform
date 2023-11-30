namespace ERP.Domain.Entities.Employees
{
    public class Attendance
    {
        public int AttendanceID { get; set; }

        // Attendance Information
        public int EmployeeID { get; set; }
        public required Employee Employee { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }

        // Additional properties and methods specific to Attendance can be added
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        EarlyLeave
    }

}

