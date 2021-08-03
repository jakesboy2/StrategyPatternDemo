namespace ConsoleApp1.Providers
{
    class DefaultCodeProvider : IAccessCodeProvider
    {
        public string GetAccessCode()
        {
            return "1234";
        }

        public string RoleName { get; } = "";
    }
}
