using ForEvolve.Blog.Samples.NinjaApi.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NinjaApi.IntegrationTests
{
	public class StartupTest : BaseHttpTest
	{
		public class ServiceProvider : StartupTest
		{
			[Fact]
			public void Should_return_both_Iga_and_Kōga_clans()
			{
				// Arrange
				var serviceProvider = Server.Host.Services;

				// Act
				var clans = serviceProvider.GetService<IEnumerable<Clan>>();

				// Assert
				Assert.NotNull(clans);
				Assert.Equal(2, clans.Count());
				Assert.Collection(clans,
					clan => Assert.Equal("Iga", clan.Name),
					clan => Assert.Equal("Kōga", clan.Name)
				);
			}
		}
	}
}
