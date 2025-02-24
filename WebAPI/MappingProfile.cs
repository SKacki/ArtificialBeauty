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
            CreateMap<Comment,CommentDTO>()
                .ReverseMap();

            CreateMap<OperationsHistory, OperationDTO>()
                .ForMember(o => o.Name, opt => opt.MapFrom(src => src.Operation != null ? src.Operation.Name : null))
                .ForMember(o => o.Description, opt => opt.MapFrom(src => src.Operation != null ? src.Operation.Description : null));

            CreateMap<User,UserDTO>()
                .ForMember(u => u.ImagesCount, opt => opt.MapFrom(src => src.Images.Count()))
                .ForMember(u => u.FollowersCount, opt => opt.MapFrom(src => src.Followers.Count()))
                .ForMember(u => u.FollowingCount, opt => opt.MapFrom(src => src.Following.Count()))
                .ForMember(u => u.Currency, opt => opt.MapFrom(src => src.OperationsHistory.Sum(x=> x.Amount)))
                .ReverseMap();
            CreateMap<Image, ImageDTO>()
                .ForMember(i => i.Tips, opt => opt.MapFrom(src => src.Tips != null ? src.Tips.Sum(x => x.Operation.Amount) : 0))
                .ForMember(i => i.Likes, opt => opt.MapFrom(src => src.Reactions != null ? src.Reactions.Count(x => x.Type == 1) : 0))
                .ForMember(i => i.Dislikes, opt => opt.MapFrom(src => src.Reactions != null ? src.Reactions.Count(x => x.Type == -1) : 0));
        }
    }
}
