using ForEvolve.Blog.Samples.NinjaApi.Models;
using ForEvolve.Blog.Samples.NinjaApi.Repositories;
using ForEvolve.Blog.Samples.NinjaApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace ForEvolve.Blog.Samples.NinjaApi
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.TryAddSingleton<IClanService, ClanService>();
			services.TryAddSingleton<IClanRepository, ClanRepository>();
			services.TryAddSingleton<IEnumerable<Clan>>(new Clan[]{
				new Clan { Name = "Iga" },
				new Clan { Name = "Kōga" },
			}); 			
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseMvc();
		}
	}
}
