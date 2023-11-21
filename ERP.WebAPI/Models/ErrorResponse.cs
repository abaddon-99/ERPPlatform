using System;
namespace ERP.WebAPI.Models
{
    public class ErrorResponse
    {
        public required string Message { get; set; }
        public string? Details { get; set; }
        // Other properties as needed
    }
}

