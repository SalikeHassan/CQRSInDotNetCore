using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.CQRS.Demo.Infrastructure.Context;
using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using AutoMapper;

namespace MS.CQRS.Demo.API
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
            services.AddDbContextPool<CandidateContext>(options => options.UseSqlServer(
              this.Configuration.GetConnectionString("CandidateConnection"), x =>
              {
                  x.MigrationsHistoryTable("__MigrationsHistoryForCandidate", "candidate");
              }));

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "DemoAPICORSPolicy",
                    builder =>
                    {
                        builder
                            //  .WithOrigins(this.Configuration.GetSection($"DemoAPICORSPolicy:Origins").Get<string[]>())
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            var serviceAssemble = AppDomain.CurrentDomain.Load("MS.CQRS.Demo.Service");
            services.AddMediatR(serviceAssemble);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("DemoAPICORSPolicy");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
