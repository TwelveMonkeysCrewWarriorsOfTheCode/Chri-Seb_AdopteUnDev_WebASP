using System.Collections.Generic;
using System.Linq;

using Adopte_Un_Dev_Conso.Models;
using Adopte_Un_Dev_Conso.Tools;

using DAL.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Adopte_Un_Dev_Conso.Controllers
{
	public class ContractController : Controller
	{

		private readonly IContractRepoLibrary _contractService;
		private readonly ISkillRepoLibrary _skillService;
		public ContractController(IContractRepoLibrary contractService, ISkillRepoLibrary skillService)
		{
			_contractService = contractService;
			_skillService = skillService;
		}

		public IActionResult GetContractAvailable()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == false)
			{
				ContractWithSkillsModel contractWithSkillsModel = new ContractWithSkillsModel();
				contractWithSkillsModel.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel());
				contractWithSkillsModel.ListContract = _contractService.GetContractAvailable().Select(d => d.MapToContractModel()).ToList(); // ToList si foreach

				foreach (var item in contractWithSkillsModel.ListContract)
				{
					item.NeededSkills = _skillService.GetNeededSkills((int)item.ContractID).Select(us => us.MapToNeededSkill());
					foreach (var text in item.NeededSkills)
					{
						var neededSkillText = contractWithSkillsModel.ListSkills
													.Where(s => s.SkillID == text.SkillID)
													.Select(s => s.Name)
													.FirstOrDefault();
						item.NeededSkillsText += neededSkillText + " ";
					}

				}
				return View(contractWithSkillsModel);
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
				ContractWithSkillsModel contractWithSkillsModel = new ContractWithSkillsModel();
				contractWithSkillsModel.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel());
				contractWithSkillsModel.ListContract = _contractService.GetContractAcceptedByDev((int)Global.UserConnected.UserId).Select(d => d.MapToContractModel()).ToList(); // ToList si foreach

				foreach (var item in contractWithSkillsModel.ListContract)
				{
					item.NeededSkills = _skillService.GetNeededSkills((int)item.ContractID).Select(us => us.MapToNeededSkill());
					foreach (var text in item.NeededSkills)
					{
						var neededSkillText = contractWithSkillsModel.ListSkills
													.Where(s => s.SkillID == text.SkillID)
													.Select(s => s.Name)
													.FirstOrDefault();
						item.NeededSkillsText += neededSkillText + " ";
					}

				}
				return View(contractWithSkillsModel);
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
				ContractWithSkillsModel contractWithSkillsModel = new ContractWithSkillsModel();
				contractWithSkillsModel.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel());
				contractWithSkillsModel.ListContract = _contractService.GetContractIssuedByClient((int)Global.UserConnected.UserId).Select(d => d.MapToContractModel()).ToList(); // ToList si foreach

				foreach (var item in contractWithSkillsModel.ListContract)
				{
					item.NeededSkills = _skillService.GetNeededSkills((int)item.ContractID).Select(us => us.MapToNeededSkill());
					foreach (var text in item.NeededSkills)
					{
						var neededSkillText = contractWithSkillsModel.ListSkills
													.Where(s => s.SkillID == text.SkillID)
													.Select(s => s.Name)
													.FirstOrDefault();
						item.NeededSkillsText += neededSkillText + " ";
					}

				}
				return View(contractWithSkillsModel);
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
		public IActionResult AddContract()
		{
			if (Global.UserConnected.UserId != null && Global.UserConnected.IsClient == true)
			{
				AddContractModel addContract = new AddContractModel();

				addContract.ListSkills = _skillService.GetSkills().Select(s => s.MapToSkillModel());
				addContract.ListNeededSkills = new List<NeededSkillsModel>();
				return View(addContract);
			}
			else
			{
				return RedirectToAction("Index", "home");
			}
		}
		[HttpPost]
		public IActionResult AddContract(AddUserSkillModel form)
		{
			form.UserID = Global.UserConnected.UserId;
			// Si le formulaire est valide
			if (ModelState.IsValid) // Propriété des controlleurs qui vérifie la validité du formulaire
			{
				//_devService.InsertUserSkill(form.MapToUserSkill());
				return RedirectToAction("GetDevWithSkills", "Dev");
			}

			return View(form);
		}
	}
}
