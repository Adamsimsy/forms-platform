﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using FormsPlatform.Contracts;
using FormsPlatform.StoreProviders;
using FormsPlatform.FormsManager;
using FormsPlatform.DecisionProviders;
using FormsPlatform.SessionProviders;

namespace FormsPlatform.Website
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services to the services container.
            services.AddMvc();
           
            services.AddSingleton<IFormsManager, DefaultManager>();
            services.AddSingleton<IStoreProvider, StaticStoreProvider>();
            services.AddSingleton<IDecisionProvider, StaticDecisionProvider>();
            services.AddSingleton<ISessionProvider, StaticSessionProvider>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            //app.UseWelcomePage();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
