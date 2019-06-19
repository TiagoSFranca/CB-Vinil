using AutoMapper;
using CBVinil.Application.GenerosMusicais.Models;
using CBVinil.Domain.Entities;

namespace CBVinil.Application.GenerosMusicais
{
    public static class GenerosMusicaisMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<GeneroMusical, GeneroMusicalViewModel>();
        }
    }
}
