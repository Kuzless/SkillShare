using AutoMapper;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Application.CQRS.User.Commands.CreateUserCommand;
using SkillShare.Application.CQRS.User.Commands.UpdateUserInfoCommand;
using SkillShare.Application.DTOs;
using SkillShare.Domain.Entities;
using SkillShare.Infrastructure.DTOs;

namespace SkillShare.API.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<UserDTO, CreateUserCommand>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserDTO, UpdateUserInfoCommand>();
            CreateMap<UpdateUserInfoCommand, User>();

            CreateMap<Chat, ChatDTO>();
            CreateMap<AddChatCommand, Chat>();
        }
    }
}
