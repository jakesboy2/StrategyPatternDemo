using ConsoleApp1.Providers;
using ConsoleApp1.Repositories;
using System.Linq;

using System.Collections.Generic;
using System.Collections.Immutable;
using System;

namespace ConsoleApp1
{
    public class RoleProviderFactory : IRoleProviderFactory
    {
        private readonly IReadOnlyDictionary<string, IAccessCodeProvider> _roleProviders;

        public RoleProviderFactory(IPretendRepository pretendRepository)
        {
            var roleProviderType = typeof(IAccessCodeProvider);
            _roleProviders = roleProviderType.Assembly.GetTypes()
                .Where(x => roleProviderType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x =>
                {
                    var parameterlessCtor = x.GetConstructors().SingleOrDefault(c => c.GetParameters().Length == 0);
                    return parameterlessCtor != null
                        ? Activator.CreateInstance(x)
                        : Activator.CreateInstance(x, pretendRepository);
                }).Cast<IAccessCodeProvider>()
                .ToImmutableDictionary(x => x.RoleName, x => x);
        }

        public IAccessCodeProvider GetProviderByRoleName(string roleName)
        {
            var provider = _roleProviders.GetValueOrDefault(roleName);
            return provider ?? _roleProviders[string.Empty];
        }

        /* Example broken down into each part
        public RoleProviderFactory(IPretendRepository pretendRepository)
        {
            var roleProviderType = typeof(IAccessCodeProvider);

            var allTypes = roleProviderType.Assembly.GetTypes();

            var implementingTypes = allTypes
                .Where(x => roleProviderType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            var createdInstances = implementingTypes
                .Select(x =>
             {
                 var parameterlessCtor = x.GetConstructors().SingleOrDefault(c => c.GetParameters().Length == 0);
                 return parameterlessCtor != null
                     ? Activator.CreateInstance(x)
                     : Activator.CreateInstance(x, pretendRepository);
             });

            var instancesInDict = createdInstances.Cast<IAccessCodeProvider>()
                .ToImmutableDictionary(x => x.RoleName, x => x);

            _roleProviders = instancesInDict;
        }
        */
    }
}
