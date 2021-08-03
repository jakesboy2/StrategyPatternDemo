using ConsoleApp1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    public class Startup
    {
        public static IServiceProvider ConfigureService()
        {
            var provider = new ServiceCollection()
                .AddTransient<IPretendRepository, PretendRepository>()
                .AddSingleton<IRoleProviderFactory, RoleProviderFactory>()
                .BuildServiceProvider();
            return provider;
        }
    }
}
