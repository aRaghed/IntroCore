﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UsingIHostApplicationLifetime
{
    internal static class Program
    {
        private static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<TimerSettings>(options =>
                        hostContext.Configuration.GetSection(TimerSettings.SectionName).Bind(options));

                    services.AddHostedService<Worker>();
                });
    }
}