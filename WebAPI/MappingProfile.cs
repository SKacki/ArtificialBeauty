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

            CreateMap<GenerationRequestDTO,MetadataDTO>()
                .ForMember(dest => dest.Lora1Weight, opt => opt.Equals(1))
                .ForMember(dest => dest.Lora2Weight, opt => opt.Equals(1))
                .ForMember(dest => dest.Height, opt => opt.Equals(1216))
                .ForMember(dest => dest.Width, opt => opt.Equals(832))
                .ForMember(dest => dest.GenDate, opt => opt.Equals(DateTime.Now));

            CreateMap<Metadata, MetadataDTO>()
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model != null ? src.Model.ModelName : null))
                .ForMember(dest => dest.Lora1Name, opt => opt.MapFrom(src => src.Lora1 != null ? src.Lora1.ModelName : null))
                .ForMember(dest => dest.Lora1Type, opt => opt.MapFrom(src => src.Lora1 != null ? src.Lora1.Type : null))
                .ForMember(dest => dest.Lora2Name, opt => opt.MapFrom(src => src.Lora2 != null ? src.Lora2.ModelName : null))
                .ForMember(dest => dest.Lora2Type, opt => opt.MapFrom(src => src.Lora2 != null ? src.Lora2.Type : null))
                .ReverseMap();

            CreateMap<Comment,CommentDTO>()
                .ForMember(i => i.UserName, opt => opt.MapFrom(src => src.User.UserName))
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
                .ForMember(i => i.Tips, opt => opt.MapFrom(src => src.Tips != null ? src.Tips.Where(x=>x.Operation.OperationId == 1).Sum(x => x.Operation.Amount) : 0))
                .ForMember(i => i.Likes, opt => opt.MapFrom(src => src.Reactions != null ? src.Reactions.Count(x => x.Type == 1) : 0))
                .ForMember(i => i.Dislikes, opt => opt.MapFrom(src => src.Reactions != null ? src.Reactions.Count(x => x.Type == -1) : 0))
                .ForMember(i => i.CommentsCount, opt => opt.MapFrom(src => src.Comments != null ? src.Comments.Count() : 0))
                .ForMember(i => i.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
