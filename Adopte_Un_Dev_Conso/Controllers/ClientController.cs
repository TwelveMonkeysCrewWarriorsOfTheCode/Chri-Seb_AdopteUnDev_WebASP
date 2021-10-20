
using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class ClientController : Controller
	{
		private readonly IUserRepoLibrary _userService;
		public ClientController(IUserRepoLibrary service)
		{
			_userService = service;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetClientById() // déplacer dans client
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				return View(_userService.GetUserById((int)Global.UserConnected.UserId).MapToUserDev());
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
	}
}
