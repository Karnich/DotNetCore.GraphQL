using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GraphQL.Types;
using DotNetCore.GraphQL.Basic.GraphQL;
using DotNetCore.GraphQL.Basic.Services;
using GraphQL;
using DotNetCore.GraphQL.Basic.Types;
using DotNetCore.GraphQL.Basic.Models;

namespace DotNetCore.GraphQL.Basic
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // configure DbSettings
            //services.AddScoped<ClaimsInputType>();
            //services.AddScoped<ClaimInputType>();
            services.AddScoped<RootQuery>();

            //Services
            services.AddScoped<GraphQLService>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<PersonType>();
            services.AddTransient<Person>();
            //services.AddTransient<UserClaimType>();
            //services.AddTransient<ClaimInterface>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new GraphQLSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<RootQuery>() });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
