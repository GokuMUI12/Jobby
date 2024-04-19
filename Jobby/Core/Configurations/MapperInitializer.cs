using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Core.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Job, JobToCreateDto>().ReverseMap();
            CreateMap<Job, JobToReturnDto>().ForMember(dest => dest.CategoryName,
                o => o.MapFrom(s => s.Category.CategoryName))
                .ForMember(dest => dest.Count, o => o.MapFrom(s => s.Offers.Count))
                .ForMember(dest => dest.Skills,
                o => o.MapFrom(s => s.Skills.Select(s => s.SkillName).ToList()))
                .ReverseMap();
            CreateMap<RegistrationDto, AppUser>()
                   .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email)).ReverseMap();
            CreateMap<UserToReturnDto, AppUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(opt => opt.Email)).ReverseMap();
            CreateMap<Offer, OfferToCreateDto>().ReverseMap();
            CreateMap<Offer, OfferToReturnDto>().
                ForMember(dest => dest.Days, o => o.MapFrom(s => s.ExpectedDaysCompletion))
                .ReverseMap();
        }
    }
}
