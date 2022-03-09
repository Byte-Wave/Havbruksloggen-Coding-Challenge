using Havbruksloggen_Coding_Challenge.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Havbruksloggen_Coding_Challenge
{
    public class Startup
    {
        public static string ConnectionString = string.Empty;
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            ConnectionString = connectionString;

            services.AddCors();
            services.AddControllers();
            services.AddRazorPages();
            services.ConfigureDependencies();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}