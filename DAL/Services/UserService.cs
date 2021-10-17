using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

using DAL.Interfaces;
using DAL.Models;

using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

namespace DAL.Services
{
	public class UserService : IUserRepoLibrary
	{
		private string _url;
		private HttpClient _client;

		public UserService(IConfiguration config)
		{
			_url = config.GetConnectionString("Default");
			_client = new HttpClient();
			_client.BaseAddress = new Uri(_url);

		}


		public UserIsClientModelDAL Login(string email, string password)
		{
			string jsonBody = JsonConvert.SerializeObject(new
			{
				email = email,
				password = password
			}
				);

			using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
			{
				using (HttpResponseMessage message = _client.PostAsync("api/User/login", content).Result)
				{
					if (!message.IsSuccessStatusCode)
					{
						throw new HttpRequestException();
					}
					string json = message.Content.ReadAsStringAsync().Result;
					Debug.Print(JsonConvert.DeserializeObject<UserIsClientModelDAL>(json).ToString());
					return JsonConvert.DeserializeObject<UserIsClientModelDAL>(json);
				}
			}
		}
		public bool Register(RegisterUserModelDAL r)
		{
			string jsonBody = JsonConvert.SerializeObject(r);

			using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
			{
				using (HttpResponseMessage message = _client.PostAsync("api/User/register", content).Result)
				{
					if (!message.IsSuccessStatusCode)
					{
						throw new HttpRequestException();
					}

					return true;
				}
			}
		}

		public IEnumerable<UserDevModelDAL> GetDevs()
		{
			using (HttpResponseMessage message = _client.GetAsync("api/User/GetDev").Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<UserDevModelDAL>>(json);
			}
		}

		public bool InsertUserSkill(AddUserSkillDAL u)
		{
			string jsonBody = JsonConvert.SerializeObject(u);

			using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
			{
				using (HttpResponseMessage message = _client.PostAsync("api/User/InsertUserSkill", content).Result)
				{
					if (!message.IsSuccessStatusCode)
					{
						throw new HttpRequestException();
					}
					return true;
				}
			}
		}

		public IEnumerable<UserSkillsDAL> GetUserSkillUserId(int id)
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/User/GetUserSkillUserId/" + id).Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<UserSkillsDAL>>(json);
			}
		}

		public UserDevModelDAL GetUserById(int id)
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/User/GetUserById/" + id).Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<UserDevModelDAL>(json);
			}
		}
	}
}
