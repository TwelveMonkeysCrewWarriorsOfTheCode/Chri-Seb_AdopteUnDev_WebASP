using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class ContractModel
	{
		public int? ContractID { get; set; }
		public string Description { get; set; }
		public int? Price { get; set; }
		public string DeadLine { get; set; }
		public int? ClientId { get; set; }
		public int? DevId { get; set; }
		public string UName { get; set; }
		public IEnumerable<NeededSkillsModel> NeededSkills { get; set; }
		public string NeededSkillsText { get; set; }
	}
}
