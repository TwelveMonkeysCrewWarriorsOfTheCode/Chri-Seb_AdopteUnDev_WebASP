using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class DevController : Controller
	{
		private readonly IUserRepoLibrary _devService;
		public DevController(IUserRepoLibrary service)
		{
			_devService = service;
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
	}
}
