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
	public class ContractService : IContractRepoLibrary
	{
		private string _url;
		private HttpClient _client;

		public ContractService(IConfiguration config)
		{
			_url = config.GetConnectionString("Default");
			_client = new HttpClient();
			_client.BaseAddress = new Uri(_url);

		}

		public IEnumerable<ContractModelDAL> GetContractAvailable()
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/Contract/GetContractAvailable").Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<ContractModelDAL>>(json);
			}
		}

		public IEnumerable<ContractModelDAL> GetContractAcceptedByDev(int id)
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/Contract/GetContractAcceptedByDev/" + id).Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<ContractModelDAL>>(json);
			}
		}

		public IEnumerable<ContractModelDAL> GetContractIssuedByClient(int id)
		{
			using (HttpResponseMessage message = _client.GetAsync("/api/Contract/GetContractIssuedByClient/" + id).Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}

				string json = message.Content.ReadAsStringAsync().Result;

				return JsonConvert.DeserializeObject<IEnumerable<ContractModelDAL>>(json);
			}
		}

		public bool InsertContract(AddContractModelDAL c)
		{
			string jsonBody = JsonConvert.SerializeObject(c);

			using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
			{
				using (HttpResponseMessage message = _client.PostAsync("/api/Contract/AddContract", content).Result)
				{
					if (!message.IsSuccessStatusCode)
					{
						throw new HttpRequestException();
					}
					return true;
				}
			}
		}

		public bool DeleteContract(int id)
		{
			using (HttpResponseMessage message = _client.DeleteAsync("api/Contract/DeleteContract/" + id).Result)
			{
				if (!message.IsSuccessStatusCode)
				{
					throw new HttpRequestException();
				}
				return true;
			}
		}
		public bool UpdateContract(EditContractModelDAL c)
		{
			string jsonBody = JsonConvert.SerializeObject(c);
			using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
			{
				using (HttpResponseMessage message = _client.PutAsync("api/Contract/UpdateContract", content).Result)
				{
					if (!message.IsSuccessStatusCode)
					{
						throw new HttpRequestException();
					}
					return true;
				}
			}
		}
	}
}
