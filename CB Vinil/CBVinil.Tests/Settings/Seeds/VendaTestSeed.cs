using CBVinil.Domain.Entities;
using CBVinil.Persistence;
using CBVinil.Tests.Settings.Interfaces;
using System;
using System.Collections.Generic;

namespace CBVinil.Tests.Settings.Seeds
{
    public class VendaTestSeed : ITestSeed
    {
        public static List<Venda> Seeds => new List<Venda>()
        {
            new Venda()
            {
                DataVenda = DateTime.Now,
                ValorCashback = 3,
                ValorEfetivo = 2,
                ValorTotal = 5
            },
            new Venda()
            {
                DataVenda = DateTime.Now,
                ValorCashback = 3,
                ValorEfetivo = 3,
                ValorTotal = 6
            },
        };

        public void Seed(CBVinilContext context)
        {
            context.Venda.AddRange(Seeds);
        }
    }
}
