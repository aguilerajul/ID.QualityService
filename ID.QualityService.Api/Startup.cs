using AutoMapper;
using ID.QualityService.Domain.Ads;
using ID.QualityService.Domain.Interfaces;
using ID.QualityService.Infrastructure;
using ID.QualityService.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ID.QualityService.Api
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

            services.AddAutoMapper(typeof(Startup));

            services.AddSingleton<IAdVOService, AdVOService>();            
            services.AddSingleton<IServiceBase<PictureVO>, PictureVOService>();
            services.AddTransient<IMemoryData, MemoryData>();

            services.AddSwaggerGen(sg =>
            {
                sg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ID Quality Service V1",
                    Version = "v1",
                    Description = "Simple API with some DDD implementation",
                    Contact = new OpenApiContact
                    {
                        Name = "Julio Aguilkera"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwagger();
            app.UseSwaggerUI(sui =>
            {
                sui.SwaggerEndpoint("/swagger/v1/swagger.json", "ID Quality Service V1");
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
