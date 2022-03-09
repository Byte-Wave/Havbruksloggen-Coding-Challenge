using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Services;

namespace Havbruksloggen_Coding_Challenge.Shared.Helpers
{
    public static class AppDependencyInjectionHelper
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<BoatAndCrewDbContext>();
            services.AddScoped<IBoatRepository, BoatRepository>();
            services.AddScoped<IBoatService, BoatService>();
        }
    }
}
