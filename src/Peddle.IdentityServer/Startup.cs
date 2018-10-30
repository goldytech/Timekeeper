// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Peddle.IdentityServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

   

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    using Peddle.IdentityServer.Models;

    public class Startup
    {
        private readonly IConfiguration configuration;

        private const string SqlConnectionString = "SQL_CONNECTION_STRING";

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddMvc();
            services.Configure<AppConfig>(
                config =>
                    {
                        config.SqlConnectionString = Environment.GetEnvironmentVariable(SqlConnectionString);
                    });
            var connectionString = configuration[SqlConnectionString];
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddIdentityServer().AddDeveloperSigningCredential() // use this only in local / dev env
                .AddConfigurationStore(
                    options =>
                        {
                            options.ConfigureDbContext = builder =>
                                    {
                                        builder.UseSqlServer(
                                            connectionString,
                                            sql => sql.MigrationsAssembly(migrationsAssembly));
                                    };
                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
