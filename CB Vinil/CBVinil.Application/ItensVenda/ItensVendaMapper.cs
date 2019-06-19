using AutoMapper;
using CBVinil.Application.ItensVenda.Models;
using CBVinil.Domain.Entities;

namespace CBVinil.Application.ItensVenda
{
    public static class ItensVendaMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<ItemVenda, ItemVendaViewModel>();
        }
    }
}
