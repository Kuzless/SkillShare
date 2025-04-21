using SkillShare.Domain.Interfaces;
using SkillShare.Infrastructure.Interfaces;

namespace SkillShare.Application.Services
{
    public class TestService : ITestInterface
    {
        private IUnitOfWork uow;
        public TestService(IUnitOfWork uow) 
        {
            this.uow = uow;
        }
        public void Test()
        {
            uow.TagRepository.GetAll();
        }
    }
}
