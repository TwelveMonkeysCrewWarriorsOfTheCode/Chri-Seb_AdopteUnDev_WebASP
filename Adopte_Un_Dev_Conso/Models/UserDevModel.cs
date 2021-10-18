using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class UserDevModel
	{
		public int UserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Telephone { get; set; }
		public IEnumerable<SkillModel> ListSkills { get; set; }
		public IEnumerable<UserSkills> UserSkills { get; set; }
		//public List<string> SkillsName { get; set; }
		//public List<string> CategoriesNam { get; set; }
	}
}
