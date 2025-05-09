﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SkillShare.Application.DTOs;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, TokensDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        private readonly IJWTService _tokenService;
        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateUserCommandHandler> logger, IPasswordHasher<Domain.Entities.User> hasher, IJWTService tokenService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _passwordHasher = hasher;
            _tokenService = tokenService;
        }
        public async Task<TokensDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<Domain.Entities.User>(request);
                user.Id = Guid.NewGuid();
                user.Password = _passwordHasher.HashPassword(user, user.Password);
                user.Roles = new List<string>() { "User" };
                var tokens = _tokenService.GenerateTokens(user);
                user.RefreshToken = tokens.RefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1);
                await _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.SaveAsync();
                return new TokensDTO() { BearerToken = tokens.BearerToken, RefreshToken = tokens.RefreshToken };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user");
                return null;
            }
        }
    }
}
