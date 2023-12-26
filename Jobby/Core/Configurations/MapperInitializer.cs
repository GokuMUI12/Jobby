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
                .ForMember(dest => dest.Skills,
                o => o.MapFrom(s => s.Skills.Select(s => s.SkillName).ToList()))
                .ReverseMap();
            CreateMap<RegistrationDto, AppUser>()
                   .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
