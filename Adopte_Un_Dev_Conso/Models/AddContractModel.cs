using System.Collections.Generic;

namespace Adopte_Un_Dev_Conso.Models
{
	public class AddContractModel
	{
		public string Description { get; set; }
		public int? Price { get; set; }
		public string DeadLine { get; set; }
		public int? ClientId { get; set; }
		public int? DevId { get; set; }
		public IEnumerable<SkillModel> ListSkills { get; set; }
		public IEnumerable<NeededSkillsModel> ListNeededSkills { get; set; }
	}
}
