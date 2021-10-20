using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using DAL.Interfaces;
using DAL.Models;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace DAL.Services
{
	public class SkillService : ISkillRepoLibrary
	{
		private string _url;
		private HttpClient _client;

		public SkillService(IConfiguration config)
		{
			_url = config.GetConnectionString("Default");
			_client = new HttpClient();
			_client.BaseAddress = new Uri(_url);

		}

		public IEnumerable<SkillsModelDAL> GetSkills()
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/Skill/GetSkill").Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<SkillsModelDAL>>(json);
			}
		}

		public IEnumerable<NeededSkillsModelDAL> GetNeededSkills(int id)
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/Skill/GetSkillContractId/" + id).Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<NeededSkillsModelDAL>>(json);
			}
		}

		public bool AddNeededSkill(AddNeededSkillModelDAL Ns)
		{
			string jsonBody = JsonConvert.SerializeObject(Ns);

			using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
			{
				using (HttpResponseMessage message = _client.PostAsync("/api/Skill/AddSkill", content).Result)
				{
					if (!message.IsSuccessStatusCode)
					{
						throw new HttpRequestException();
					}
				}
			}
			return true;
		}
	}
}
