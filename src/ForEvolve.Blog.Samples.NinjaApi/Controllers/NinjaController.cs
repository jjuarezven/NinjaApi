using ForEvolve.Blog.Samples.NinjaApi.Models;
using ForEvolve.Blog.Samples.NinjaApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForEvolve.Blog.Samples.NinjaApi.Controllers
{
	[Route("v1/[controller]")]
	public class NinjaController : Controller
	{
		private readonly INinjaService _ninjaService;
		public NinjaController(INinjaService ninjaService)
		{
			_ninjaService = ninjaService ?? throw new ArgumentNullException(nameof(ninjaService));
		}

		[HttpGet]
		[ProducesResponseType(typeof(IEnumerable<Ninja>), StatusCodes.Status200OK)]
		public async Task<IActionResult> ReadAllAsync()
		{
			return Ok(await _ninjaService.ReadAllAsync());
		}

		[HttpGet("{clan}")]
		[ProducesResponseType(typeof(IEnumerable<Ninja>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> ReadAllInClanAsync(string clan)
		{
			try
			{
				return Ok(await _ninjaService.ReadAllInClanAsync(clan));
			}
			catch (ClanNotFoundException)
			{
				return NotFound();
			}
			
		}

		[HttpGet("{clan}/{key}")]
		[ProducesResponseType(typeof(Ninja), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> ReadOneAsync(string clan, string key)
		{
			try
			{
				return Ok(await _ninjaService.ReadOneAsync(clan, key));
			}
			catch (NinjaNotFoundException)
			{
				return NotFound();
			}
		}

		[HttpPost]
		[ProducesResponseType(typeof(Ninja), StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateAsync([FromBody]Ninja ninja)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var createdNinja = await _ninjaService.CreateAsync(ninja);
			return CreatedAtAction(
				nameof(ReadOneAsync),
				new { clan = createdNinja.Clan.Name, key = createdNinja.Key },
				createdNinja
			);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Ninja), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateAsync([FromBody]Ninja ninja)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				return Ok(await _ninjaService.UpdateAsync(ninja));
			}
			catch (NinjaNotFoundException)
			{
				return NotFound();
			}
		}

		[HttpDelete("{clan}/{key}")]
		[ProducesResponseType(typeof(Ninja), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteAsync(string clan, string key)
		{
			try
			{
				return Ok(await _ninjaService.DeleteAsync(clan, key));
			}
			catch (NinjaNotFoundException)
			{
				return NotFound();
			}
		}
	}
}
