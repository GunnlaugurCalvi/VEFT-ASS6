﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaPlanet.Repositories;
using PizzaPlanet.Services;


namespace API
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
            services.AddMemoryCache();
            services.AddMvc();
            services.AddTransient<IPizzaPlanetRepository, PizzaPlanetRepository>();
            services.AddTransient<IPizzaPlanetService, PizzaPlanetService>();
            services.AddDbContext<AppDataContext>(options => 
               options.UseSqlite("Data Source=../Repositories/PizzaPlanet.db", b => b.MigrationsAssembly("API")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
