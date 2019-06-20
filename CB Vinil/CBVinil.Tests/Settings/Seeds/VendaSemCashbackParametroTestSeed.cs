using CBVinil.Domain.Seeds;
using CBVinil.Persistence;
using CBVinil.Tests.Settings.Interfaces;

namespace CBVinil.Tests.Settings.Seeds
{
    public class VendaSemCashbackParametroTestSeed : ITestSeed
    {
        public void Seed(CBVinilContext context)
        {
            context.GeneroMusical.AddRange(GeneroMusicalSeed.Seeds);
            context.DiaSemana.AddRange(DiaSemanaSeed.Seeds);
            context.Disco.AddRange(DiscoTestSeed.Seeds);
            context.Venda.AddRange(VendaTestSeed.Seeds);
        }
    }
}
