using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class DevWithSkillsModel
	{
		public UserDevModel Dev { get; set; }
		public IEnumerable<SkillModel> ListSkills { get; set; }
		public IEnumerable<UserSkillsModel> UserSkills { get; set; }
		public IEnumerable<CategoryModel> Categories { get; set; }
	}
}
