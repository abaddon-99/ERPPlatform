namespace ERP.Domain.Models
{
	public class User
	{
		public int UserID { get; set; }
		public required string Username { get; set; }
		public required string Password { get; set; }
		public required string Email { get; set; }
	}
}

