using DotNetCorePoc.Api.App_start;
using DotNetCorePoc.Api.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;

namespace DotNetCorePoc.Api
{
    class Program
    {
        const string _hostUrlKey = "HostUrl";

        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {

                })
                .UseContentRoot(pathToContentRoot)
                .UseUrls(ConfigHelper.GetAppSettingValue<string>(_hostUrlKey))
                                .UseStartup<Startup>();
        }
    }
}
