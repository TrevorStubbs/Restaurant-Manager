using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightningLawInterviewRound1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LightningLawInterviewRound1.IntegrationTests.TestConfigurations
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var removeDbThisConnection = services.SingleOrDefault(r => r.ServiceType == typeof(DbContextOptions<LightningLawInterviewRound1Context>));

                services.Remove(removeDbThisConnection);

                services.AddDbContext<LightningLawInterviewRound1Context>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider;
                    var database = scopedService.GetRequiredService<LightningLawInterviewRound1Context>();
                    var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    database.Database.EnsureCreated();
                }
            });
        }
    }
}
