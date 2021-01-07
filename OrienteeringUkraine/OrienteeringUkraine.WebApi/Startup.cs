using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrienteeringUkraine.Application.Infrastructure.AutoMapper.Extensions;
using OrienteeringUkraine.Application.Infrastructure.Mediator.Extensions;
using OrienteeringUkraine.Application.Infrastructure.Validation.Extensions;
using OrienteeringUkraine.WebApi.Infrastructure.Data.Extensions;

namespace OrienteeringUkraine.WebApi
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
            services.AddControllers()
                    .AddCustomValidation();

            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});
            services.AddDatabase(Configuration);
            services.AddCustomMediator();
            services.AddCustomAutoMapper();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orienteering Ukraine API", Version = "v1" });
            });
            #region Api Versioning
            //services.AddApiVersioning(
            //   options =>
            //   {
            //       // use api v1.0 by default
            //       options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            //       options.AssumeDefaultVersionWhenUnspecified = true;
            //       // if not specified in header 
            //       options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            //       options.ReportApiVersions = true;
            //   });

            //services.AddVersionedApiExplorer(
            //    options =>
            //    {
            //        //Format: vMajorVersion.MinorVersion
            //        options.GroupNameFormat = "'v'VV";
            //        options.SubstituteApiVersionInUrl = true;
            //    });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orienteering Ukraine API v1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseStaticFiles();

            app.MigrateDatabase(Configuration);
            app.SeedDatabase(Configuration);

            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
