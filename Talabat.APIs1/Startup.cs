using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talabat.APIs1.Errors;
using Talabat.APIs1.Extenstions;
using Talabat.APIs1.Middlewares;
using Talabat.Core.Repository;
using Talabat.Repository;
using Talabat.Repository.Entites;
using Talabat.Service.Data;

namespace Talabat.APIs1
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Talabat.APIs1", Version = "v1" });
            });

            services.AddDbContext<StoreDbConetxt>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnetions"));
            });

            services.AddApplicationServices();

            services.AddSingleton<IConnectionMultiplexer>(s =>
            {
                var connection = ConfigurationOptions.Parse( Configuration.GetConnectionString("redisConnections"));

                return ConnectionMultiplexer.Connect(connection);
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionsMiddlewares>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Talabat.APIs1 v1"));
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
