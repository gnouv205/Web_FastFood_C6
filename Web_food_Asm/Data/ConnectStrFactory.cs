using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Web_food_Asm.Data
{
	public class ConnectStrFactory : IDesignTimeDbContextFactory<ConnectStr>
	{
		public ConnectStr CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<ConnectStr>();
			var connectionString = configuration.GetConnectionString("ConnectStr");
			optionsBuilder.UseSqlServer(connectionString);

			return new ConnectStr(optionsBuilder.Options);
		}
	}
}
