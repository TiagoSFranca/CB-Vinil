using CBVinil.Domain.Entities;
using CBVinil.Domain.Seeds;
using CBVinil.Persistence;
using CBVinil.Tests.Settings.Interfaces;
using System;
using System.Collections.Generic;

namespace CBVinil.Tests.Settings.Seeds
{
    public class DiscoTestSeed : ITestSeed
    {
        public static List<Disco> Seeds => new List<Disco>() {
            new Disco()
            {
                IdGeneroMusical = GeneroMusicalSeed.Classic.IdGeneroMusical,
                Nome = "Disco 01",
                Artistas = "a1",
                CodSpotify = Guid.NewGuid().ToString(),
                Preco = 1
            },
            new Disco()
            {
                IdGeneroMusical = GeneroMusicalSeed.Pop.IdGeneroMusical,
                Nome = "Disco 02",
                Artistas = "a12",
                CodSpotify = Guid.NewGuid().ToString(),
                Preco = 21
            },
            new Disco()
            {
                IdGeneroMusical = GeneroMusicalSeed.Rock.IdGeneroMusical,
                Nome = "Disco 03",
                Artistas = "a11",
                CodSpotify = Guid.NewGuid().ToString(),
                Preco = 14
            },
            new Disco()
            {
                IdGeneroMusical = GeneroMusicalSeed.Mpb.IdGeneroMusical,
                Nome = "Disco 04",
                Artistas = "a15",
                CodSpotify = Guid.NewGuid().ToString(),
                Preco = 41
            },
        };

        public void Seed(CBVinilContext context)
        {
            context.GeneroMusical.AddRange(GeneroMusicalSeed.Seeds);
            context.Disco.AddRange(Seeds);
        }
    }
}
