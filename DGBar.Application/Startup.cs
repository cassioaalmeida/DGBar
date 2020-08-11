using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DGBar.Domain.Entities;
using DGBar.Domain.Interfaces;
using DGBar.Infrastructure.CrossCutting.IOC;
using DGBar.Infrastructure.Data.Context;
using DGBar.Infrastructure.Data.Repository;
using DGBar.Domain.Interfaces.Services;
using DGBar.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DGBar.Application
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
            var connection = Configuration["SqliteConnection:SqliteConnectionString"];
            services.AddDbContext<Context>(options =>
                options.UseSqlite(connection)
            );
            //services.AddServiceDependency();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddTransient<IBaseRepository<Product>, ProductRepository>();
            //services.AddScoped(typeof(IBaseRepository<Product>), typeof(BaseRepository<Product>));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder Builder)
        {
            Builder.RegisterModule(new ModuleIOC());
        }
    }
}
