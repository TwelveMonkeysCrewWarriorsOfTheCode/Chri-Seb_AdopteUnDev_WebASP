using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class AddUserSkillModel
	{
		public int? UserID { get; set; }
		public int? SkillID { get; set; }
		public IEnumerable<SkillModel> ListSkills { get; set; }
	}
}
