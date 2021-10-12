using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adopte_Un_Dev_Conso.Controllers
{
    public class DevController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
