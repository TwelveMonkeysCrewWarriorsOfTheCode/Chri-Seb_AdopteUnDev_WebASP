
using System.Linq;

using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class SkillController : Controller
	{
		private readonly ISkillRepoLibrary _userService;
		public SkillController(ISkillRepoLibrary service)
		{
			_userService = service;
		}

		public IActionResult GetSkills()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				return View(_userService.GetSkills().Select(d => d.MapToSkillModel()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
	}
}
