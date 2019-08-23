using ForEvolve.Blog.Samples.NinjaApi.Models;
using ForEvolve.Blog.Samples.NinjaApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ForEvolve.Blog.Samples.NinjaApi.Controllers
{
	[Route("v1/[controller]")]
	public class ClansController : Controller
	{
		private readonly IClanService _clanService;

		public ClansController(IClanService clanService)
		{
			_clanService = clanService ?? throw new ArgumentNullException(nameof(clanService));
		}

		// GET: api/<controller>
		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Clan>), 200)]
		public async Task<IActionResult> ReadAllAsync()
		{
			var allClans = await _clanService.ReadAllAsync();
			return Ok(allClans);
		}
	}
}
