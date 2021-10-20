using System.Diagnostics;

using Adopte_Un_Dev_Conso.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (Global.UserConnected.UserId != null)
			{
				if (Global.UserConnected.IsClient == false)
				{
					return RedirectToAction("GetDevWithSkills", "Dev");
				}
				else if (Global.UserConnected.IsClient == true)
				{
					return RedirectToAction("GetClientById", "Client");
				}
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Logout()
		{
			Global.UserConnected.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}
