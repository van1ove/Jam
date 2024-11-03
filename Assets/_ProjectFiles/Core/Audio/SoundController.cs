using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;

namespace _ProjectFiles.Core.Audio
{
    public class SoundController : MonoBehaviour
    {
        private AudioSource _audioSource;
        private SoundService _soundService;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _soundService = ServiceLocator.GetService<SoundService>();
            UpdateVolume(_soundService.Volume);
            _soundService.OnValueUpdated += UpdateVolume;
        }
        
        private void OnEnable()
        {
            if (_soundService is null)
                return;
            
            _soundService.OnValueUpdated += UpdateVolume;
        }

        private void OnDisable()
        {
            _soundService.OnValueUpdated -= UpdateVolume;
        }
        
        private void UpdateVolume(float value) => _audioSource.volume = value;
    }
}