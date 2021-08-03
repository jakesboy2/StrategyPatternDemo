using System;
using Microsoft.Extensions.DependencyInjection;
using ConsoleApp1.Factories;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string workerRole = "worker";
            const string managerRole = "manager";
            const string defaultRole = "";
            var container = Startup.ConfigureService();
            var roleProviderFactory = container.GetRequiredService<IRoleProviderFactory>();

            var workerAccessCodeProvider = roleProviderFactory.GetProviderByRoleName(workerRole);
            var managerAccessCodeProvider = roleProviderFactory.GetProviderByRoleName(managerRole);
            var defaultAccessCodeProvider = roleProviderFactory.GetProviderByRoleName(defaultRole);

            // Call each provider and display access code
            Console.WriteLine("Worker Code: " + workerAccessCodeProvider.GetAccessCode());
            Console.WriteLine("Manager Code: " + managerAccessCodeProvider.GetAccessCode());
            Console.WriteLine("Default Code: " + defaultAccessCodeProvider.GetAccessCode());
        }
    }
}
