using System;
using System.Collections.Generic;
using System.Net.Http;

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
	}
}
