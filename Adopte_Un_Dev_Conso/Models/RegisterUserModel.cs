using System.ComponentModel.DataAnnotations;

namespace Adopte_Un_Dev_Conso.Models
{
	public class RegisterUserModel
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
