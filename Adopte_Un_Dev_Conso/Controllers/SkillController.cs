
using System.Linq;

using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class SkillController : Controller
	{
		private readonly ISkillRepoLibrary _skillService;
		public SkillController(ISkillRepoLibrary skillService)
		{
			_skillService = skillService;
		}

		public IActionResult GetSkills()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				return View(_skillService.GetSkills().Select(d => d.MapToSkillModel()));
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
		//public IActionResult AddNeededSkill()
		//{
		//	if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
		//	{
		//		AddContractModel addContract = new AddContractModel();

		//		addContract.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel());
		//		addContract.ListNeededSkills = new List<NeededSkillsModel>();
		//		return View(addContract);
		//	}
		//	else
		//	{
		//		return RedirectToAction("Index", "home");
		//	}
		//}
		//[HttpPost]
		//public IActionResult AddNeededSkill(AddContractModel form)
		//{
		//	form.ClientId = Global.UserConnected.UserId;
		//	// Si le formulaire est valide
		//	if (ModelState.IsValid) // Propriété des controlleurs qui vérifie la validité du formulaire
		//	{
		//		_skillService.AddNeededSkill(item.MapToNeededSkill());

		//		return RedirectToAction("GetDevWithSkills", "Dev");
		//	}

		//	return View(form);
		//}
	}
}
