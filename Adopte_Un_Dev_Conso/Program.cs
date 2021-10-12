
using Adopte_Un_Dev_Conso.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Adopte_Un_Dev_Conso
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}


	public static class Global
	{
		public static UserIsClientModel UserConnected = new UserIsClientModel();
	}
}
