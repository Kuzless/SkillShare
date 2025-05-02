using AutoMapper;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Application.CQRS.Message.Commands.SendMessageCommand;
using SkillShare.Application.CQRS.User.Commands.CreateUserCommand;
using SkillShare.Application.CQRS.User.Commands.UpdateUserInfoCommand;
using SkillShare.Application.DTOs;
using SkillShare.Domain.Entities;

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
            CreateMap<User, UserPropositionsDTO>();

            CreateMap<Chat, ChatDTO>();
            CreateMap<AddChatCommand, Chat>();

            CreateMap<SendMessageDTO, SendMessageCommand>();
            CreateMap<SendMessageCommand, Message>();
            CreateMap<Message, MessageDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name));
        }
    }
}
