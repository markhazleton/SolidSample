using ArdalisRating.Core;
using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.Raters;
using ArdalisRating.Infrastructure;
using ArdalisRating.Infrastructure.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArdalisRatingWebApi
{
        /// <summary>
        /// Startup for Core Web Application
        /// </summary>
        public class Startup
    {
        /// <summary>
        /// Startup constructor with configuration parameter
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllersWithViews();
            services.AddMvc(options =>
            {
                options.InputFormatters.Insert(0, new RawJsonBodyInputFormatter());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddScoped<ILogger, InMemoryLogger>();
            services.AddScoped<IBatchLogger, InMemoryLogger>();
            services.AddScoped<StringPolicySource>();
            services.AddScoped<IPolicySource, StringPolicySource>(sp => sp.GetRequiredService<StringPolicySource>());
            services.AddScoped<IPolicySerializer, JsonPolicySerializer>();
            services.AddScoped<IRaterFactory,RaterFactory>();
            services.AddScoped<IRatingEngine,RatingEngine>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
