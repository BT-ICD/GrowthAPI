using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Growth.API
{
    public class Program
    {
        static string env = "";
        //const string env = "Dev";
        public static void Main(string[] args)
        {
            
            NLog.Logger  logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {

                //To read appsetting json for Environment - Dev stands for development
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var result = config.GetSection("Env").GetSection("Env").Value;
                env = result;
                if (env == "Dev")
                {
                    logger = NLog.Web.NLogBuilder.ConfigureNLog("nlogDev.config").GetCurrentClassLogger();
                }
                logger.Debug("init main");
    
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((a, config) =>{
                    config.AddJsonFile($"appsettings{env}.json");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                }).UseNLog();  // NLog: Setup NLog for Dependency injection
    }
}
