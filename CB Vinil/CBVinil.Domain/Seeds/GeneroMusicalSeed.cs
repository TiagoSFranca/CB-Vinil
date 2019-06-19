using CBVinil.Domain.Entities;
using System.Collections.Generic;

namespace CBVinil.Domain.Seeds
{
    public static class GeneroMusicalSeed
    {
        public static GeneroMusical Pop => new GeneroMusical() { IdGeneroMusical = 1, Nome = "POP" };
        public static GeneroMusical Mpb => new GeneroMusical() { IdGeneroMusical = 2, Nome = "MPB" };
        public static GeneroMusical Classic => new GeneroMusical() { IdGeneroMusical = 3, Nome = "CLASSIC" };
        public static GeneroMusical Rock => new GeneroMusical() { IdGeneroMusical = 4, Nome = "ROCK" };

        public static List<GeneroMusical> Seeds => new List<GeneroMusical>() {
            Pop,
            Mpb,
            Classic,
            Rock
        };
    }
}
