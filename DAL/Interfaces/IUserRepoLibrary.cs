using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface IUserRepoLibrary
	{
		public UserIsClientModelDAL Login(string email, string password);
		public bool Register(RegisterUserModelDAL r);
		public IEnumerable<UserDevModelDAL> GetDevs();
		public bool InsertUserSkill(AddUserSkillDAL u);
		public IEnumerable<UserSkillsDAL> GetUserSkillUserId(int id);
		public UserDevModelDAL GetUserById(int id);
		public bool DeleteUserSkills(int id);
		public bool UpdateUserSkill(EditUserSkillDAL u);
	}
}