using ConsoleApp1.Repositories;

namespace ConsoleApp1.Providers
{
    class WorkerAccessCodeProvider : IAccessCodeProvider
    {
        private readonly IPretendRepository _pretendRepository;

        public WorkerAccessCodeProvider(IPretendRepository pretendRepository)
        {
            _pretendRepository = pretendRepository;
        }

        public string GetAccessCode()
        {
            return _pretendRepository.GetWorkerAccessCode();
        }

        public string RoleName { get; } = "worker";
    }
}
