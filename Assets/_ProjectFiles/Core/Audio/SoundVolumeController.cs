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
            InitService();
            UpdateVolume(_soundVolumeService.Volume);
            _soundVolumeService.OnValueUpdated += UpdateVolume;
        }
        
        private void OnEnable()
        {
            if (_soundVolumeService is null)
                return;
            
            _soundVolumeService.OnValueUpdated += UpdateVolume;
        }

        private void OnDisable()
        {
            _soundVolumeService.OnValueUpdated -= UpdateVolume;
        }
        
        private void UpdateVolume(float value) => _audioSource.volume = value;
        
        private void InitService()
        {
            _soundVolumeService = ServiceLocator.GetService<SoundVolumeService>();
            if (_soundVolumeService is not null) 
                return;
            
            ServiceLocator.RegisterService<SoundVolumeService>(new SoundVolumeService());
            _soundVolumeService = ServiceLocator.GetService<SoundVolumeService>();
        }
    }
}