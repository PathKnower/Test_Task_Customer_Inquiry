﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Npgsql;

using NSwag;
using NSwag.AspNetCore;

using Test_Task_Customer_Inquiry.Services;

namespace Test_Task_Customer_Inquiry
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationContext>(config => 
            {
                config.UseLazyLoadingProxies();
                //config.UseNpgsql(Configuration.GetConnectionString("DB"));
                config.UseSqlServer(Configuration.GetConnectionString("SqlDB"));
            });

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IInquiryService, InquiryService>();

            services.AddOpenApiDocument(document =>
            {
                document.PostProcess = d =>
                {
                    d.Info.Title = "Customer Inquiry";
                };
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
