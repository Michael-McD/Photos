using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhotoAlbum.api.Services;

namespace PhotoAlbum.api
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
            services.AddHttpClient<IPhotoAlbumService, PhotoAlbumService>(c =>
            {
                c.BaseAddress = new Uri("http://jsonplaceholder.typicode.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            
            services.AddHttpClient<IF1DriverService, F1DriverService>(c =>
            {
                c.BaseAddress = new Uri("http://ergast.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
