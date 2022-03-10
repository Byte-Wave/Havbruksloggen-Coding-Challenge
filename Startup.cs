using Havbruksloggen_Coding_Challenge.Shared.Helpers;
using Havbruksloggen_Coding_Challenge.Shared.Services;
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
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddCors();
            services.AddControllers();
            services.AddRazorPages();
            services.ConfigureDependencies(Configuration);

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