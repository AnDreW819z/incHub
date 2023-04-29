using AutoMapper;
using incHub.Dto;
using incHub.Models;

namespace incHub.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
        }
    }
}
