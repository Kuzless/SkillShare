using AutoMapper;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Domain.Entities;
using SkillShare.Infrastructure.DTOs;

namespace SkillShare.API.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Chat, ChatDTO>().ReverseMap();
            CreateMap<AddChatCommand, Chat>();
        }
    }
}
