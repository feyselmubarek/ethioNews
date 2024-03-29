﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthioNews.Data;
using EthioNews.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EthioNews
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<EthioNewsDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddSingleton<EthioRepoterCrawler>();
            services.AddScoped<INewsData, NewsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Not Found");
            });
        }
    }
}
