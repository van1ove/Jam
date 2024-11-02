using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;

namespace _ProjectFiles.Core.Audio
{
    public class SoundVolumeController : MonoBehaviour
    {
        private AudioSource _audioSource;
        private SoundVolumeService _soundVolumeService;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _soundVolumeService = ServiceLocator.GetService<SoundVolumeService>();
        }
        
        
    }
}