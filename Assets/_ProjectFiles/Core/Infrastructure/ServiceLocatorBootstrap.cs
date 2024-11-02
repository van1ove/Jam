using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;

namespace _ProjectFiles.Core.Infrastructure
{
    public class ServiceLocatorBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            InitService<SoundService>();
        }

        private void InitService<T>() where T : IService, new()
        {
            T obj = new T();
            ServiceLocator.ServiceLocator.RegisterService<T>(obj);
        }
    }
}