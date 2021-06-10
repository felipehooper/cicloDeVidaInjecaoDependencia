using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC_DI.Services;

namespace POC_DI
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Clico de Vida

            services.AddTransient<IUserTransient, User>();
            services.AddScoped<IUserScoped, User>();
            services.AddSingleton<IUserSingleton, User>();
            services.AddTransient<UserService>();

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
