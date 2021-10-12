using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface ISkillRepoLibrary
	{
		public IEnumerable<SkillsModelDAL> GetSkills();
	}
}
