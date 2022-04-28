using Microsoft.EntityFrameworkCore;
namespace FootballAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options): base(options) { }

		public DbSet<FootballPlayer> FootballPlayers { get; set; }

	}

    
}

