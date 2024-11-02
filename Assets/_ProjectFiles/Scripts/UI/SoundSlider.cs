using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectFiles.Scripts.UI
{
    public class SoundSlider : MonoBehaviour
    {
        private Slider _soundVolumeSlider;
        private SoundVolumeService _soundVolumeService;

        private void Awake()
        {
            _soundVolumeSlider = GetComponent<Slider>();
            InitService();
        }

        private void OnEnable()
        {
            _soundVolumeSlider.value = _soundVolumeService.Volume;
            _soundVolumeSlider.onValueChanged.AddListener(_soundVolumeService.UpdateVolumeValue);
        }

        private void OnDisable()
        {
            _soundVolumeSlider.onValueChanged.RemoveListener(_soundVolumeService.UpdateVolumeValue);
        }

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