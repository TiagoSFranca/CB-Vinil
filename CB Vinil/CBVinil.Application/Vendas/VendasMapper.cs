using AutoMapper;
using CBVinil.Application.Vendas.Models;
using CBVinil.Domain.Entities;

namespace CBVinil.Application.Vendas
{
    public static class VendasMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Venda, VendaViewModel>();
        }
    }
}
