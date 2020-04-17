using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;

namespace psl.API
{
    public partial class Startup
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }
        private MapperConfiguration _mapperConfiguration { get; set; }
        public Startup(IHostEnvironment env)
        {
            //Set up AutoMapper
            _mapperConfiguration = new MapperConfiguration(config =>
            {
            });

            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddJsonFile("localConnectionStrings.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                //dev specific things
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureAppSettings(services, Configuration);
            //Cross-origin Resource Sharing
            //Browsers will shut down POSTs across domains if preflight doesn't work.
            //https://en.wikipedia.org/wiki/Cross-origin_resource_sharing#Simple_example
            ConfigureCorsServices(services);

            services.AddMvc()
                .AddNewtonsoftJson(options =>
           options.SerializerSettings.ContractResolver =
              new CamelCasePropertyNamesContractResolver())
            ;

            //EF, Dapper, database related stuff would go here.
            ConfigureOrmServices(Configuration, services);

            //Identity/IdentityServer/Token generation.
            ConfigureAuthServices(Configuration, services);

            //API Documentation.
            ConfigureSwaggerServices(services);

            services.AddSingleton(sp => _mapperConfiguration.CreateMapper());

            //Scoped Services
            ConfigureScopedServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider services, ILoggerFactory loggerFactory)
        {
            app.UseRouting();

            ConfigureCors(app, env);

            ConfigureOrm(app, env);

            ConfigureErrors(app, services, loggerFactory);

            ConfigureAuth(app, env, loggerFactory, Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureSwagger(app, env);
        }
    }
}
