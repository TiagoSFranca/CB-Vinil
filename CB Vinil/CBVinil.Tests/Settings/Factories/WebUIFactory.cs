using CBVinil.API;
using CBVinil.Persistence;
using CBVinil.Tests.Settings.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CBVinil.Tests.Settings.Factories
{
    public class WebUIFactory : WebApplicationFactory<Startup>
    {
        private ITestSeed _seed { get; set; }

        public WebUIFactory(ITestSeed seed)
        {
            _seed = seed;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .AddEntityFrameworkProxies()
                    .BuildServiceProvider();

                services.AddDbContext<CBVinilContext>(options =>
                    options.UseInMemoryDatabase("TESTE")
                        .UseInternalServiceProvider(serviceProvider)
                        .UseLazyLoadingProxies());

                services.AddCors();

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var gCCartasContext = scopedServices.GetRequiredService<CBVinilContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<WebUIFactory>>();

                    gCCartasContext.Database.EnsureCreated();

                    try
                    {
                        _seed.Seed(gCCartasContext);
                        gCCartasContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Ocorreu um erro durante a migração ou inicialização da base de dados de testes. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
