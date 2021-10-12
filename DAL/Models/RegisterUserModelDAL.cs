using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
	public class RegisterUserModelDAL
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		public string Telephone { get; set; }
		[Required]
		public bool IsClient { get; set; }
	}
}
