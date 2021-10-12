using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class ClientController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
