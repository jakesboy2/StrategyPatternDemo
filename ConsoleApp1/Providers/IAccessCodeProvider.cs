namespace ConsoleApp1.Providers
{
    public interface IAccessCodeProvider
    {
        public string GetAccessCode();
        public string RoleName { get; }
    }
}
