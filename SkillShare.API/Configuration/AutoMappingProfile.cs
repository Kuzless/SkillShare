using AutoMapper;
using SkillShare.Application.CQRS.Chat.Commands.AddChatCommand;
using SkillShare.Application.CQRS.Message.Commands.SendMessageCommand;
using SkillShare.Application.CQRS.Rating.Commands.AddRatingReviewCommand;
using SkillShare.Application.CQRS.Rating.Commands.ChangeRatingReviewCommand;
using SkillShare.Application.CQRS.Tag.Commands.AddTagToUserCommand;
using SkillShare.Application.CQRS.Tag.Commands.CreateNewTagCommand;
using SkillShare.Application.CQRS.Tag.Commands.DeleteTagCommand;
using SkillShare.Application.CQRS.Tag.Commands.RemoveTagFromUserCommand;
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
            // User maps
            CreateMap<UserDTO, CreateUserCommand>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserDTO, UpdateUserInfoCommand>();
            CreateMap<UpdateUserInfoCommand, User>();
            CreateMap<User, UserPropositionsDTO>();

            // Chat maps
            CreateMap<Chat, ChatDTO>();
            CreateMap<AddChatCommand, Chat>();

            // Message maps
            CreateMap<SendMessageDTO, SendMessageCommand>();
            CreateMap<SendMessageCommand, Message>();
            CreateMap<Message, MessageDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name));

            // Rating maps
            CreateMap<RateDTO, AddRatingReviewCommand>();
            CreateMap<AddRatingReviewCommand, Rating>();
            CreateMap<RateDTO, ChangeRatingReviewCommand>();
            CreateMap<ChangeRatingReviewCommand, Rating>();

            // Tag maps
            CreateMap<TagDTO, CreateNewTagCommand>();
            CreateMap<CreateNewTagCommand, Tag>();
            CreateMap<TagDTO, DeleteTagCommand>();
            CreateMap<DeleteTagCommand, Tag>();
            CreateMap<UserTagDTO, AddTagToUserCommand>();
            CreateMap<UserTagDTO, RemoveTagFromUserCommand>();
            CreateMap<Tag, TagDTO>();
        }
    }
}