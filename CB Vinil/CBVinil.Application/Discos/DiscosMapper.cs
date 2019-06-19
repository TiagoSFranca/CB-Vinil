using AutoMapper;
using CBVinil.Application.Discos.Models;
using CBVinil.Domain.Entities;

namespace CBVinil.Application.Discos
{
    public static class DiscosMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Disco, DiscoViewModel>();
        }
    }
}
