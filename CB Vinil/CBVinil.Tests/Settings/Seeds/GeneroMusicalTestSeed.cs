using CBVinil.Domain.Seeds;
using CBVinil.Persistence;
using CBVinil.Tests.Settings.Interfaces;

namespace CBVinil.Tests.Settings.Seeds
{
    public class GeneroMusicalTestSeed : ITestSeed
    {
        public void Seed(CBVinilContext context)
        {
            context.GeneroMusical.AddRange(GeneroMusicalSeed.Seeds);
        }
    }
}
