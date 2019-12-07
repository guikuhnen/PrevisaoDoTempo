using API.PrevisaoDoTempo.Application.Services;
using API.PrevisaoDoTempo.Infra.Data.Context;
using API.PrevisaoDoTempo.Infra.Data.Repository;
using API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Configuration;
using API.PrevisaoDoTempo.Infra.External.OpenWeatherAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using API.PrevisaoDoTempo.WebAPI.Utils;

namespace API.PrevisaoDoTempo.WebAPI
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

            services.AddDbContext<PrevisaoDoTempoContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // TODO services.AddCors();

            services.Configure<OpenWeatherApiConfiguration>(Configuration.GetSection("OpenWeatherApiConfiguration"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Services

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IExternalCityService, ExternalCityService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            // TODO app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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
