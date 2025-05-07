using AutoMapper;
using MediatR;
using SkillShare.Application.DTOs.User;
using SkillShare.Domain.Interfaces;

namespace SkillShare.Application.CQRS.User.Queries.GetPropositionsQuery
{
    public class GetPropositionsQueryHandler : IRequestHandler<GetPropositionsQuery, List<UserPropositionsDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetPropositionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<UserPropositionsDTO>> Handle(GetPropositionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRepository.GetPropositions(request.UserId);
            return _mapper.Map<List<UserPropositionsDTO>>(result);
        }
    }
}
