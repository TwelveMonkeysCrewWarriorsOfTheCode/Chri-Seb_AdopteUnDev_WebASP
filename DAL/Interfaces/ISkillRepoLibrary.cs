using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface ISkillRepoLibrary
	{
		public IEnumerable<SkillsModelDAL> GetSkills();
		public IEnumerable<NeededSkillsModelDAL> GetNeededSkills(int id);
		public bool AddNeededSkill(AddNeededSkillModelDAL Ns);
	}
}
