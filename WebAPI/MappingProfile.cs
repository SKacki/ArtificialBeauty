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
            CreateMap<User,UserDTO>()
                .ForMember(u => u.ImagesCount, opt => opt.MapFrom(src => src.Images.Count()))
                .ForMember(u => u.FollowersCount, opt => opt.MapFrom(src => src.Followers.Count()))
                .ForMember(u => u.FollowingCount, opt => opt.MapFrom(src => src.Following.Count()))
                .ForMember(u => u.Currency, opt => opt.MapFrom(src => src.OperationsHistory.Sum(x=> x.Amount)))
                .ForMember(u => u.ShowcaseImages, opt => opt.MapFrom(src => src.Images.OrderBy(x=>x.UploadDate).Take(10)))
                .ReverseMap();
        }
    }
}
