using AutoMapper;
using CBVinil.Application.Discos;
using CBVinil.Application.GenerosMusicais;
using CBVinil.Application.ItensVenda;
using CBVinil.Application.Vendas;

namespace CBVinil.Application.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            GenerosMusicaisMapper.Map(this);
            DiscosMapper.Map(this);
            VendasMapper.Map(this);
            ItensVendaMapper.Map(this);
        }
    }
}
