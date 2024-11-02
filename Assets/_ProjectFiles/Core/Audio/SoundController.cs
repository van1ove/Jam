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
            Update(_soundService.Volume);
            _soundService.OnValueUpdated += Update;
        }
        
        private void OnEnable()
        {
            if (_soundService is null)
                return;
            
            _soundService.OnValueUpdated += Update;
        }

        private void OnDisable()
        {
            _soundService.OnValueUpdated -= Update;
        }
        
        private void Update(float value) => _audioSource.volume = value;
    }
}