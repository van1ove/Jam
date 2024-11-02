using System;
using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;
using UnityEngine.UI;

namespace _ProjectFiles.Core.UI
{
    public class SoundSlider : MonoBehaviour
    {
        private Slider _soundVolumeSlider;
        private SoundService _soundService;

        private void Start()
        {
            _soundVolumeSlider = GetComponent<Slider>();
            _soundService = ServiceLocator.GetService<SoundService>();
            _soundVolumeSlider.value = _soundService.Volume;
            _soundVolumeSlider.onValueChanged.AddListener(_soundService.UpdateVolumeValue);
        }

        private void OnEnable()
        {
            if (_soundVolumeSlider is null)
                return;
            
            _soundVolumeSlider.value = _soundService.Volume;
            _soundVolumeSlider.onValueChanged.AddListener(_soundService.UpdateVolumeValue);
        }

        private void OnDisable()
        {
            _soundVolumeSlider.onValueChanged.RemoveListener(_soundService.UpdateVolumeValue);
        }
    }
}