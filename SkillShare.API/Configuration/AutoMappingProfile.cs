using AutoMapper;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Domain.Entities;

namespace SkillShare.API.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<AddChatCommand, Chat>().ReverseMap();
        }
    }
}
