using CBVinil.Persistence;
using CBVinil.Tests.Settings.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CBVinil.Tests.Settings.Factories
{
    public static class CBVinilContextFactoryTests
    {
        public static CBVinilContext Create(ITestSeed seed)
        {
            var dbName = Guid.NewGuid().ToString() + DateTime.Now.ToLongTimeString();

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddEntityFrameworkProxies()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<CBVinilContext>()
                .UseInMemoryDatabase(dbName)
                .UseInternalServiceProvider(serviceProvider)
                .UseLazyLoadingProxies()
                .Options;

            var context = new CBVinilContext(options);

            context.Database.EnsureDeleted();

            context.Database.EnsureCreated();

            if (seed != null)
                seed.Seed(context);

            context.SaveChanges();

            return context;
        }

        public static void Destroy(CBVinilContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
