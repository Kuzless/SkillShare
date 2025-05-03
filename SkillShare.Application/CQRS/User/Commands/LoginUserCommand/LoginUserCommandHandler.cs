using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkillShare.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using SkillShare.Application.Interfaces;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Commands.LoginUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokensDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LoginUserCommandHandler> _logger;
        private readonly IPasswordHasher<Domain.Entities.User> _passwordHasher;
        private readonly IJWTService _tokenService;
        public LoginUserCommandHandler(IUnitOfWork unitOfWork, ILogger<LoginUserCommandHandler> logger, IPasswordHasher<Domain.Entities.User> hasher, IJWTService tokenService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _passwordHasher = hasher;
            _tokenService = tokenService;
        }
        public async Task<TokensDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetByEmail(request.Email);
                var isPasswordCorrect = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
                if (isPasswordCorrect == PasswordVerificationResult.Failed)
                {
                    throw new Exception("Invalid password");
                }
                var tokens = _tokenService.GenerateTokens(user);
                user.RefreshToken = tokens.RefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1);
                await _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveAsync();
                return new TokensDTO() { BearerToken = tokens.BearerToken, RefreshToken = tokens.RefreshToken };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Invalid credentials");
                return null;
            }
        }
    }
}
