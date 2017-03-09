using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuanLyKho.Data;
using QuanLyKho.Data.Infrastructure;
using System;

namespace QuanLyKho.WebCMS
{
    public class Startup
    {
        private static string _applicationPath = string.Empty;

        private string sqlConnectionString = string.Empty;

        private bool useInMemoryProvider = false;

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            // Setup configuration sources.

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This reads the configuration keys from the secret store.
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<AppsDbContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            try
            {
                string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
                }
                catch { }

                services.AddDbContext<AppsDbContext>(options =>
                {
                    switch (useInMemoryProvider)
                    {
                        case true:
                            options.UseInMemoryDatabase();
                            break;

                        default:
                            //    options.UseSqlServer(sqlConnectionString,
                            //b => b.MigrationsAssembly("QuanLyKho.Data"));
                            options.UseSqlServer(sqlConnectionString);
                            break;
                    }
                });

                services.AddSingleton<IUnitOfWork, UnitOfWork>();

                // Repositories

                //Enabling Cross-Origin Requests
                services.AddCors();

                // Add framework services.
                services.AddMvc();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}