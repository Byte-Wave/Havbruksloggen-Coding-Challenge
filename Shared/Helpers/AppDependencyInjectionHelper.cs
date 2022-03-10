using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Models.Database;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Repositories;
using Havbruksloggen_Coding_Challenge.BoatAndCrewManager.Services;
using Havbruksloggen_Coding_Challenge.Shared.Services;

namespace Havbruksloggen_Coding_Challenge.Shared.Helpers
{
    public static class AppDependencyInjectionHelper
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var rootFilePath = configuration.GetValue<string>("FilesPath");
            services.AddScoped<PathMaker>(c => new PathMaker(rootFilePath));


            services.AddTransient<BoatAndCrewDbContext>();

            services.AddScoped<ICrewRepository, CrewRepository>();
            services.AddScoped<ICrewService, CrewService>();

            services.AddScoped<IBoatRepository, BoatRepository>();
            services.AddScoped<IBoatService, BoatService>();

          
    

        }
    }
}
