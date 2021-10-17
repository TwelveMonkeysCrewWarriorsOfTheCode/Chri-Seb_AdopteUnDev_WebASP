using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class DevWithSkillsModel
	{
		public UserDevModel Dev { get; set; }
		public IEnumerable<SkillModel> ListSkills { get; set; }
		public IEnumerable<UserSkills> UserSkills { get; set; }
	}
}
