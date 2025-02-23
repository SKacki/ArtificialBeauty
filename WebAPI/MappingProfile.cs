using AutoMapper;
using DAL;
using Model.Models;
using model = DAL.Model;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<model, ModelDTO>()
                .ReverseMap();

            CreateMap<Metadata, MetadataDTO>()
                .ReverseMap();


        }
    }
}
