namespace ERP.Domain.Entities
{
    public class ErrorResponse
    {
        public required string Message { get; set; }
        public string? Details { get; set; }
    }
}

