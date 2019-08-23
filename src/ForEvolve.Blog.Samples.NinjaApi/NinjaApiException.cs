using ForEvolve.Blog.Samples.NinjaApi.Models;
using System;
using System.Runtime.Serialization;

namespace ForEvolve.Blog.Samples.NinjaApi
{
	public class NinjaApiException : Exception
	{
		public NinjaApiException()
		{
		}

		public NinjaApiException(string message) : base(message)
		{
		}

		public NinjaApiException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected NinjaApiException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

	public class ClanNotFoundException : NinjaApiException
	{
		public ClanNotFoundException(Clan clan)
			: this(clan.Name)
		{
		}

		public ClanNotFoundException(string clanName)
			: base($"Clan {clanName} was not found.")
		{
		}
	}

	public class NinjaNotFoundException : NinjaApiException
	{
		public NinjaNotFoundException(Ninja ninja)
			: base($"Ninja {ninja.Name} ({ninja.Key}) of clan {ninja.Clan.Name} was not found.")
		{
		}

		public NinjaNotFoundException(string clanName, string ninjaKey)
			: base($"Ninja {ninjaKey} of clan {clanName} was not found.")
		{
		}
	}
}
