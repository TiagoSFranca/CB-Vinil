using CBVinil.Domain.Seeds;
using System.Linq;

namespace CBVinil.Persistence
{
    public class CBVinilInitializer
    {
        public static void Initialize(CBVinilContext context)
        {
            var instance = new CBVinilInitializer();
            instance.Seed(context);
        }

        public void Seed(CBVinilContext context)
        {
            context.Database.EnsureCreated();

            if (!context.GeneroMusical.Any())
                SeedGeneroMusical(context);

            if (!context.DiaSemana.Any())
                SeedDiaSemana(context);

            if (!context.CashbackParametro.Any())
                SeedCashbackParametro(context);
        }

        private void SeedCashbackParametro(CBVinilContext context)
        {
            context.CashbackParametro.AddRange(CashbackParametroSeed.Seeds);
        }

        private void SeedDiaSemana(CBVinilContext context)
        {
            context.DiaSemana.AddRange(DiaSemanaSeed.Seeds);
        }

        public void SeedGeneroMusical(CBVinilContext context)
        {
            context.GeneroMusical.AddRange(GeneroMusicalSeed.Seeds);
        }
    }
}
