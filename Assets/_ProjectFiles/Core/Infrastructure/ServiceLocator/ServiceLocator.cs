using System;
using System.Collections.Generic;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;

namespace _ProjectFiles.Core.Infrastructure.ServiceLocator
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, IService> Services = new Dictionary<Type, IService>();

        public static T GetService<T>() where T : IService
        {
            if (Services.ContainsKey(typeof(T))) 
                return (T)Services[typeof(T)];

            return default;
        }

        public static void RegisterService<T>(IService service) where T : IService
        {
            if (!Services.ContainsKey(typeof(T)))
            {
                Services.Add(typeof(T), service);
            }
        }

        public static void UnregisterService<T>() where T : IService
        {
            if (!Services.ContainsKey(typeof(T)))
            {
                Services.Remove(typeof(T));
            }
        }
    }
}