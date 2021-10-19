using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class ContractWithSkillsModel
	{
		public IEnumerable<ContractModel> ListContract { get; set; }
		public IEnumerable<SkillModel> ListSkills { get; set; }
	}
}
