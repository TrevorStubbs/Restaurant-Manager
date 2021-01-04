/*
 * This code is based off of 'Integration tests in ASP.NET Core' in the official Microsoft Documentation
 * https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0
 */

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
    /// <summary>
    /// This class allows the tester to build CustomWebApplication needed to run system integration tests. 
    /// </summary>
    /// <typeparam name="TStartup">The SUT's Startup.cs file.</typeparam>
    
    // My plan is to either add to this class when a new integration setup is required or make this a base class for derived classes to use to build specific configurations. 
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // This removes the connection to the real database so that we don't damage production data.
                var removeDbThisConnection = services.SingleOrDefault(r => r.ServiceType == typeof(DbContextOptions<LightningLawInterviewRound1Context>));

                services.Remove(removeDbThisConnection);

                // Here we are adding a connection to EF's in-memory database to this Web Application's startup.
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
