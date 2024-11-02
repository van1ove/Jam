using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;
using UnityEngine.Video;

namespace _ProjectFiles.Core.Video
{
    public class VideoController : MonoBehaviour
    {
        private VideoPlayer _videoPlayer;
        private SoundService _soundService;
        
        private void Start()
        {
            _videoPlayer = GetComponent<VideoPlayer>();
            _videoPlayer.Prepare();
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
        
        private void UpdateVolume(float value) => _videoPlayer.SetDirectAudioVolume(0, value);
    }
}