﻿using System.Linq;

using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class ContractController : Controller
	{

		private readonly IContractRepoLibrary _userService;
		public ContractController(IContractRepoLibrary service)
		{
			_userService = service;
		}

		public IActionResult GetContractAvailable()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == false)
			{
				return View(_userService.GetContractAvailable().Select(d => d.MapToContractModel()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}

		public IActionResult GetContractAcceptedByDev()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == false)
			{
				return View(_userService.GetContractAcceptedByDev((int)Global.UserConnected.UserId).Select(d => d.MapToContractModel()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}

		public IActionResult GetContractIssuedByClient()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				return View(_userService.GetContractIssuedByClient((int)Global.UserConnected.UserId).Select(d => d.MapToContractModel()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
	}
}