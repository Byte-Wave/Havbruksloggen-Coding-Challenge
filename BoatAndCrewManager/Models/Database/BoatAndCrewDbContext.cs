using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database.Mappings;
using Havbruksloggen_Coding_Challenge.BoatAndCrewMemberManager.Models.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database
{
    public class BoatAndCrewDbContext : DbContext
    {
        public DbSet<BoatEntity> Boats { get; set; }
        public DbSet<CrewMemberEntity> CrewMembers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
                builder.UseNpgsql(Startup.ConnectionString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BoatMap());
            builder.ApplyConfiguration(new CrewMemberMap());
        }
    }
}
