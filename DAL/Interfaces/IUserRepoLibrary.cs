using System.Collections.Generic;

using DAL.Models;

namespace DAL.Interfaces
{
	public interface IUserRepoLibrary
	{
		//public UserIsClientModelDAL Login(LoginUserModelDAL l);
		public UserIsClientModelDAL Login(string email, string password);
		public bool Register(RegisterUserModelDAL r);
		public IEnumerable<UserDevModelDAL> GetDevs();
	}
}