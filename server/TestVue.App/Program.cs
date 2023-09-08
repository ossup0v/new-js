using System.Net;
using Serilog;

namespace TestVue;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>();
                        //.UseUrls("http://*:8081");
                })
                .ConfigureLogging((context, builder) =>
                {
                    builder.ClearProviders();
                })
                .UseSerilog((context, provider, cfg) =>
                {
                    cfg.ReadFrom.Configuration(context.Configuration);
                    cfg.Enrich.FromLogContext();
                    cfg.Enrich.WithProperty("machine_name", Environment.MachineName);
                    cfg.Enrich.WithProperty("environment", context.HostingEnvironment.EnvironmentName);
                    cfg.Enrich.WithProperty("log_source", context.HostingEnvironment.ApplicationName);
                });
    }

