using AutoMapper;
using DeliverIT.Application;
using DeliverIT.Application.Interfaces;
using DeliverIT.Application.Mappings;
using DeliverIT.Data;
using DeliverIT.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DeliverIT.WebAPI
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
            services.AddScoped<IContaPagarRepository, ContaPagarRepository>();
            services.AddScoped<IContaPagarApp, ContaPagarApp>();

            services.AddAutoMapper(p => p.AddProfile(new ContaPagarMapping()), typeof(Startup));

            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Contas a Pagar API",
                    Description = "Inclusão e consulta de contas a pagar",
                    Contact = new OpenApiContact
                    {
                        Name = "Anderson Davanse",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/andervanse"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
                config.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
