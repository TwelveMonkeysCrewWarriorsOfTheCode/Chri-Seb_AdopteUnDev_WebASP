namespace Adopte_Un_Dev_Conso.Models
{
	public class UserIsClientModel
	{
		public int? UserId { get; set; }
		public string Email { get; set; }
		//public string Password { get; set; }

		public bool? IsClient { get; set; }

		public void Clear()
		{
			UserId = null;
			Email = "";
			IsClient = null;
		}
	}
}
