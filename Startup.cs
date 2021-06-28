using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ServiceLifetime
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IWebHostEnvironment webHostEnvironment,IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        public IHostEnvironment HostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //Lifetime services
            services.AddSingleton<ISingletonObject>(s => new Operation());
            //services.AddSingleton<ISingletonObject>(s => new Operation(Guid.Empty));

            //check out if there's an injection assigned to ISingletonObject beforehand
            //if so, skip otherwise assign it.
            services.TryAddSingleton<ISingletonObject>(s => new Operation(Guid.Empty));
            services.AddSingleton<ISingleton,Operation>();
            services.AddScoped<IScoped,Operation>();
            services.AddTransient<ITransient,Operation>();

            //Test Services
            services.AddTransient<IServiceMarkerOne,ServiceOne>();
            services.AddTransient<IServiceMarkerTwo,ServiceTwo>();

            //Second Option For Test Services
            //services.AddTransient<ServiceOne,ServiceOne>();
            //services.AddTransient<ServiceTwo,ServiceTwo>();

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
    }
}
