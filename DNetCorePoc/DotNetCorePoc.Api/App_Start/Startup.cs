using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using DotNetCorePoc.Api.Repositories;
using DotNetCorePoc.Api.BusinessServices;
using DotNetCorePoc.Api.ExcelReader;

namespace DotNetCorePoc.Api.App_start
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStorageRepsitory, FileRepository>();
            services.AddTransient<IUploadBusinessService, UploadBusinessService>();
            services.AddTransient<IExcelReader, OleDbExcelReader>();
            services.AddMvc();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var repository = serviceScope.ServiceProvider.GetRequiredService<IStorageRepsitory>();
                repository.Configure("H:\\Projects");
            }
            app.UseMvc();
        }

    }
}
