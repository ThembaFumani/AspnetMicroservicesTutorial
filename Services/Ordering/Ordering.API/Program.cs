    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
using Ordering.Infrastructure.Persistence;
using Ordering.API.Extensions;

    namespace Ordering.API
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                 CreateHostBuilder(args)
                    .Build()
                    .MigrationDatase<OrderContext>((context, services) =>
                    {
                        var logger = services.GetService<ILogger<OrderContextSeed>>();
                        OrderContextSeed.SeedAsync(context, logger).Wait();
                    })
                    .Run();
            }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
        }
    }

