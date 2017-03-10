using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuanLyKho.Data;
using QuanLyKho.Data.Infrastructure;
using QuanLyKho.Data.Repositories;
using QuanLyKho.Service;
using System;
using System.Reflection;
using QuanLyKho.WebCMS.Api;

namespace QuanLyKho.WebCMS
{
    public class Startup
    {
        private static string _applicationPath = string.Empty;

        private string sqlConnectionString = string.Empty;

        private bool useInMemoryProvider = false;

        // Using Autofac
        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }

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

        //Hung Ly - Added third-party Containner to MVC Core
        public IServiceProvider ConfigureServices(IServiceCollection services)
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
                            options.UseSqlServer(sqlConnectionString,
                        b => b.MigrationsAssembly("QuanLyKho.Data"));
                            //options.UseSqlServer(sqlConnectionString);
                            break;
                    }
                });

                services.AddSingleton<IUnitOfWork, UnitOfWork>();

                // Register all Repositories

                //Enabling Cross-Origin Requests
                services.AddCors();

                // ASP.NET Core docs for Autofac are here:
                // http://autofac.readthedocs.io/en/latest/integration/aspnetcore.html

                // Hung Ly - Controller as Services Add framework services.
                services.AddMvc().AddControllersAsServices();

                // Create the Autofac container builder.
                var builder = new ContainerBuilder();


                //builder.RegisterControllers(Assembly.GetExecutingAssembly());
                builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly());

                //// Register your Web API controllers.


                //// Register WebApi Controllers
                //builder.regisRegisterApiControllers(Assembly.GetExecutingAssembly());

                //builder.RegisterAssemblyTypes(typeof(PostCategoryController).GetTypeInfo().Assembly)
                //    .Where(t => t.Name.EndsWith("Controller"))
                //    .PropertiesAutowired();


                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

                builder.RegisterType<AppsDbContext>().AsSelf().InstancePerRequest();

                //Asp.net Identity
                //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
                //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
                //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
                //builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
                //builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

                
                //var assemblies = Assembly.GetEntryAssembly().GetRattlesAssemblies();
                ////.SelectMany(s => s.GetTypes())
                ////        .Where(p => !p.IsAbstract && !p.IsInterface && p.IsClass); ;
                //foreach (var assembly in assemblies)
                //{
                //    builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();

                //}

                // Repositories
                builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).GetTypeInfo().Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();

                // Services
                builder.RegisterAssemblyTypes(typeof(PostCategoryService).GetTypeInfo().Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

                //Autofac.IContainer container = builder.Build();
                //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

                //Set the WebApi DependencyResolver
                //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

                // Populate the services.
                builder.Populate(services);

                // Build the container.
                ApplicationContainer = builder.Build();

                // Create and return the service provider.
                return new AutofacServiceProvider(this.ApplicationContainer);
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