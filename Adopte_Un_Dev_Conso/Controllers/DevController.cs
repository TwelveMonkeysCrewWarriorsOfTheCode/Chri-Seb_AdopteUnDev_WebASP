using System.Linq;

using Adopte_Un_Dev_Conso.Models;
using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class DevController : Controller
	{
		private readonly IUserRepoLibrary _devService;
		private readonly ISkillRepoLibrary _skillService;
		public DevController(IUserRepoLibrary devService, ISkillRepoLibrary skillService)
		{
			_devService = devService;
			_skillService = skillService;
		}
		public IActionResult Index(int id)
		{
			return View();
		}


		public IActionResult GetDevById()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == false)
			{
				return View(_devService.GetUserById((int)Global.UserConnected.UserId).MapToUserDev());
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}


		public IActionResult GetUserSkillUserId()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				return View(_devService.GetUserSkillUserId((int)Global.UserConnected.UserId).Select(us => us.MapToUserSkill()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}

		public IActionResult GetDevWithSkills()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == false)
			{
				UserDevModel userDev = _devService.GetUserById((int)Global.UserConnected.UserId).MapToUserDev();
				userDev.UserSkills = _devService.GetUserSkillUserId((int)Global.UserConnected.UserId).Select(us => us.MapToUserSkill());
				userDev.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel());
				//foreach (var us in userDev.UserSkills)
				//{
				//	foreach (var ls in userDev.ListSkills)
				//	{
				//		if (us.SkillID == ls.SkillID)
				//		{
				//			userDev.SkillsName.Add(ls.Name);
				//			userDev.CategoriesNam.Add(ls.CName);
				//		}
				//	}
				//}
				//userDev.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel()).ToList(); // ToList si foreach

				//return RedirectToAction("GetDevWithSkills", "Dev", userDev);
				return View(userDev);
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
	}
}
