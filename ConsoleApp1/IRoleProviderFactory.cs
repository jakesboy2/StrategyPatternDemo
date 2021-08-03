using ConsoleApp1.Providers;
namespace ConsoleApp1
{
    public interface IRoleProviderFactory
    {
        public IAccessCodeProvider GetProviderByRoleName(string role);
    }
}
