using ForEvolve.Blog.Samples.NinjaApi.Models;
using ForEvolve.Blog.Samples.NinjaApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForEvolve.Blog.Samples.NinjaApi.Services
{
	public class NinjaService : INinjaService
	{
		private readonly INinjaRepository _ninjaRepository;
		private readonly IClanService _clanService;

		public NinjaService(INinjaRepository ninjaRepository, IClanService clanService)
		{
			_ninjaRepository = ninjaRepository ?? throw new ArgumentNullException(nameof(ninjaRepository));
			_clanService = clanService ?? throw new ArgumentNullException(nameof(clanService));
		}

		public async Task<Ninja> CreateAsync(Ninja ninja)
		{
			return await _ninjaRepository.CreateAsync(ninja);
		}

		public async Task<Ninja> DeleteAsync(string clanName, string ninjaKey)
		{
			var remoteNinja = await _ninjaRepository.ReadOneAsync(clanName, ninjaKey);
			if (remoteNinja == null)
			{
				throw new NinjaNotFoundException(clanName, ninjaKey);
			}
			return await _ninjaRepository.DeleteAsync(clanName, ninjaKey);
		}

		public Task<IEnumerable<Ninja>> ReadAllAsync()
		{
			return _ninjaRepository.ReadAllAsync();
		}

		public async Task<IEnumerable<Ninja>> ReadAllInClanAsync(string clanName)
		{
			var isClanExist = await _clanService.IsClanExistsAsync(clanName);
			if (!isClanExist)
			{
				throw new ClanNotFoundException(clanName);
			}
			return await _ninjaRepository.ReadAllInClanAsync(clanName);
		}

		public async Task<Ninja> ReadOneAsync(string clanName, string ninjaKey)
		{
			var ninja = await _ninjaRepository.ReadOneAsync(clanName, ninjaKey);
			if (ninja == null)
			{
				throw new NinjaNotFoundException(clanName, ninjaKey);
			}
			return ninja;
		}

		public async Task<Ninja> UpdateAsync(Ninja ninja)
		{
			var remoteNinja = await ReadOneAsync(ninja.Clan.Name, ninja.Key);
			if (remoteNinja == null)
			{
				throw new NinjaNotFoundException(ninja.Clan.Name, ninja.Key);				
			}
			return await _ninjaRepository.UpdateAsync(ninja);
		}
	}
}
