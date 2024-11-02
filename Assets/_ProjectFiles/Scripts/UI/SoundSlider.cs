using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace _ProjectFiles.Scripts.UI
{
    public class SoundSlider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textField;
        private Scrollbar _soundVolumeSlider;
        private SoundVolumeService _soundVolumeService;

        private void Awake()
        {
            _soundVolumeSlider = GetComponent<Scrollbar>();
            InitService();
        }

        private void OnEnable()
        {
            _soundVolumeSlider.value = _soundVolumeService.Volume;
            _soundVolumeSlider.onValueChanged.AddListener(_soundVolumeService.UpdateVolumeValue);
            _soundVolumeSlider.onValueChanged.AddListener(UpdateSoundText);
        }

        private void OnDisable()
        {
            _soundVolumeSlider.onValueChanged.RemoveListener(_soundVolumeService.UpdateVolumeValue);
            _soundVolumeSlider.onValueChanged.RemoveListener(UpdateSoundText);
        }

        private void InitService()
        {
            _soundVolumeService = ServiceLocator.GetService<SoundVolumeService>();
            if (_soundVolumeService is not null) 
                return;
            
            ServiceLocator.RegisterService<SoundVolumeService>(new SoundVolumeService());
            _soundVolumeService = ServiceLocator.GetService<SoundVolumeService>();
        }

        private void UpdateSoundText(float newValue) => textField.text = $"Звук: {(int)(newValue * 100)}%" ; 
    }
}