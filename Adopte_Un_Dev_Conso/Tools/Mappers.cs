using Adopte_Un_Dev_Conso.Models;

using DAL.Models;

namespace Adopte_Un_Dev_Conso.Tools
{
	public static class Mappers
	{
		public static UserIsClientModel MapFromUserLogin(this DAL.Models.UserIsClientModelDAL l)
		{
			return new UserIsClientModel
			{
				UserId = l.UserId,
				Email = l.Email,
				IsClient = l.IsClient
			};
		}
		public static LoginUserModel MapToUserLogin(this DAL.Models.LoginUserModelDAL l)
		{
			return new LoginUserModel
			{
				Email = l.Email,
				Password = l.Password
			};
		}
		public static RegisterUserModelDAL MapToRegisterUser(this RegisterUserModel l)
		{
			return new RegisterUserModelDAL
			{
				Name = l.Name,
				Email = l.Email,
				Password = l.Password,
				Telephone = l.Telephone,
				IsClient = l.IsClient
			};
		}

		public static UserDevModel MapToUserModel(this UserDevModelDAL u)
		{
			return new UserDevModel
			{
				UserID = u.UserID,
				Name = u.Name,
				Email = u.Email,
				Telephone = u.Telephone
			};
		}

		public static SkillModel MapToSkillModel(this SkillsModelDAL s)
		{
			return new SkillModel
			{
				SkillID = s.SkillID,
				Name = s.Name,
				Description = s.Description,
				CName = s.CName
			};
		}

		public static ContractModel MapToContractModel(this ContractModelDAL c)
		{
			return new ContractModel
			{
				ContractID = c.ContractID,
				Description = c.Description,
				Price = c.Price,
				DeadLine = c.DeadLine,
				ClientId = c.ClientId,
				DevId = c.DevId,
				UName = c.UName
			};
		}

		public static AddUserSkillDAL MapToUserSkill(this AddUserSkillModel u)
		{
			return new AddUserSkillDAL
			{
				UserID = u.UserID,
				SkillID = u.SkillID
			};
		}

		public static UserDevModel MapToUserDev(this UserDevModelDAL u)
		{
			return new UserDevModel
			{
				UserID = u.UserID,
				Name = u.Name,
				Email = u.Email,
				Telephone = u.Telephone
			};
		}

		public static UserSkills MapToUserSkill(this UserSkillsDAL us)
		{
			return new UserSkills
			{
				UserSkillID = us.UserSkillID,
				UserID = us.UserID,
				SkillID = us.SkillID
			};
		}

		public static NeededSkillsModel MapToNeededSkill(this NeededSkillsModelDAL ns)
		{
			return new NeededSkillsModel
			{
				NeededSkillID = ns.NeededSkillID,
				ContractID = ns.ContractID,
				SkillID = ns.SkillID
			};
		}
	}
}
