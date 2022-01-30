using BusinessLogicLayer.Services;
using DataAccessLayer;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentMigrator.Runner;
using System.Reflection;

namespace TestTaskAliExpress
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddFluentMigratorCore()
              .ConfigureRunner(config =>
                               config.AddPostgres()
              .WithGlobalConnectionString(Configuration.GetConnectionString("DefaultConnection"))
              .ScanIn(Assembly.GetExecutingAssembly()).For.All());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //https://dotnetcorecentral.com/blog/fluentmigrator/
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
