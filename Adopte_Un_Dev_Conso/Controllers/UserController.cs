using System.Linq;

using Adopte_Un_Dev_Conso.Models;
using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserRepoLibrary _userService;
		public UserController(IUserRepoLibrary service)
		{
			_userService = service;
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login([FromForm] LoginUserModel form)
		{
			if (!ModelState.IsValid)
			{
				return View(form);
			}
			//Console.WriteLine($"Login user1 : {form.Email} {form.Password}");
			Models.UserIsClientModel connectedUser = new Models.UserIsClientModel();
			connectedUser = _userService.Login(form.Email, form.Password).MapFromUserLogin();
			//Console.WriteLine($"Login user2 : {connectedUser.Email} {connectedUser.IsClient}");

			Global.UserConnected = connectedUser;

			if (connectedUser.IsClient == false)
			{
				return RedirectToAction("Index", "Dev");
			}
			else
			{
				return RedirectToAction("Index", "Client");
			}

		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(RegisterUserModel form)
		{
			// Si le formulaire est valide
			if (ModelState.IsValid) // Propriété des controlleurs qui vérifie la validité du formulaire
			{
				_userService.Register(form.MapToRegisterUser());
				return RedirectToAction("Index", "home");
			}

			return View(form);
		}


		public IActionResult GetDevs()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				return View(_userService.GetDevs().Select(d => d.MapToUserModel()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
		public IActionResult AddUserSkill()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddUserSkill(AddUserSkillModel form)
		{
			// Si le formulaire est valide
			if (ModelState.IsValid) // Propriété des controlleurs qui vérifie la validité du formulaire
			{
				_userService.InsertUserSkill(form.MapToUserSkill());
				return RedirectToAction("Index", "Dev");
			}

			return View(form);
		}
	}
}
