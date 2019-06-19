using AutoMapper;
using CBVinil.Application.GenerosMusicais;

namespace CBVinil.Application.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            GenerosMusicaisMapper.Map(this);
        }
    }
}
