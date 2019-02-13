using AdventureWorksApi.Managers;
using AdventureWorksApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdventureWorksApi
{
    public class Startup
    {
        public Startup()
        {
            // Create a builder
            var configurationBuilder = new ConfigurationBuilder();

            // Build the configuration
            Configuration = configurationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configuration
            services.Configure<Configs.ApplicationConfig>(Configuration);

            // Registration
            var namespaces = new[]
            {
                "AdventureWorksApi.Controllers",
                "AdventureWorksApi.Managers",
                "AdventureWorksApi.Repositories"
            };
            Assembly
                .GetAssembly(typeof(Startup))
                .GetTypes()
                .ToList()
                .ForEach(type =>
                {
                    if (namespaces.Contains(type.Namespace))
                    {
                        services.AddTransient(type);
                    }
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Identify the environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Use the proper methods for the app builder
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Customer}/{action=GetAll}/{id?}");
            });
        }
    }
}
