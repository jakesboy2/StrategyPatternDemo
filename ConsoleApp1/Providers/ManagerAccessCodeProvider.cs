using ConsoleApp1.Repositories;

namespace ConsoleApp1.Providers
{
    public class ManagerAccessCodeProvider : IAccessCodeProvider
    {
        private readonly IPretendRepository _pretendRepository;

        public ManagerAccessCodeProvider(IPretendRepository pretendRepository)
        {
            _pretendRepository = pretendRepository;
        }
        public string GetAccessCode()
        {
            return _pretendRepository.GetManagerAccessCode();
        }

        public string RoleName { get; } = "manager";
    }
}
