using AutoMapper;

namespace Day1WebApi.Mapper
{
    public class AsetMapper : Profile
    {
        public AsetMapper()
        {
            CreateMap<AsetDto, Aset>();
            CreateMap<Aset, AsetDto>();
        }

    }
}
