using AutoMapper;
using Model.Models;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DAL.Model, ModelDTO>()
                .ReverseMap();

        }
    }
}
