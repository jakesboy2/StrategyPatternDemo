using ConsoleApp1.Providers;
namespace ConsoleApp1.Factories
{
    public interface IRoleProviderFactory
    {
        public IAccessCodeProvider GetProviderByRoleName(string role);
    }
}
