using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForEvolve.Blog.Samples.NinjaApi.Models;

namespace ForEvolve.Blog.Samples.NinjaApi.Repositories
{
	public class ClanRepository : IClanRepository
	{
		private readonly List<Clan> _clans;

		public ClanRepository(IEnumerable<Clan> clans)
		{
			if (clans == null)
			{
				throw new ArgumentNullException(nameof(clans));
			}
			_clans = new List<Clan>(clans);
		}		

		public Task<IEnumerable<Clan>> ReadAllAsync()
		{
			return Task.FromResult(_clans.AsEnumerable());
		}

		public Task<Clan> ReadOneAsync(string clanName)
		{
			return Task.FromResult(_clans.FirstOrDefault(x => x.Name == clanName));
		}

		public Task<Clan> CreateAsync(Clan clan)
		{
			throw new NotSupportedException();
		}

		public Task<Clan> UpdateAsync(Clan clan)
		{
			throw new NotSupportedException();
		}

		public Task<Clan> DeleteAsync(string clanName)
		{
			throw new NotSupportedException();
		}		
	}
}
