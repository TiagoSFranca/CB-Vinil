using CBVinil.Persistence.Settings;
using Microsoft.EntityFrameworkCore;

namespace CBVinil.Persistence
{
    public class CBVinilContextFactory : DesignTimeDbContextFactoryBase<CBVinilContext>
    {
        protected override CBVinilContext CreateNewInstance(DbContextOptions<CBVinilContext> options)
        {
            return new CBVinilContext(options);
        }
    }
}
