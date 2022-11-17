using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CromulentBisgetti.DemoApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {

                    // 11/16/2022 09:24 pm - SSN - [20221116-2038] - [004] - Removed with .NET Core 3.1
                    // See [20221116-2038] - [002] for replacement fix. API will not work without.

                    // Todo options.SerializerSettings.ContractResolver
                    // options.SerializerSettings.ContractResolver = null;


                })

                // 11/16/2022 08:44 pm - SSN - [20221116-2038] - [002] - Upgrade to .NET Core 3.1
                // Fix replacement for [20221116-2038] - [001] app.UseMvcWithDefaultRoute();

                // Install NuGet package 
                //Id                : Microsoft.AspNetCore.Mvc.NewtonsoftJson
                //Versions          : {3.1.31}



                .AddMvcOptions(mvcOptions =>
                {
                    mvcOptions.EnableEndpointRouting = false;
                });


            // 11/16/2022 09:13 pm - SSN - [20221116-2038] - [003] - Upgrade to .NET Core 3.1
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();



            // 11/16/2022 08:38 pm - SSN - [20221116-2038] - [001] - Upgrade to .NET Core 3.1

            // Endpoint Routing does not support 'IApplicationBuilder.UseMvc(...)'. 
            // To use 'IApplicationBuilder.UseMvc' set 'MvcOptions.EnableEndpointRouting = false' 
            // inside 'ConfigureServices(...).
            // See [20221116-2038] - [001] for applied fix.

            app.UseMvcWithDefaultRoute();
        }
    }
}
