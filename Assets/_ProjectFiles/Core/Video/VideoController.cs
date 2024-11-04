using _ProjectFiles.Core.Infrastructure.ServiceLocator;
using _ProjectFiles.Core.Infrastructure.ServiceLocator.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
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
			_videoPlayer.loopPointReached += TurnOffVideo;
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

		private void TurnOffVideo(VideoPlayer player)
		{
			if (_videoPlayer.clip.name == "�������� 2")
			{
				SceneManager.LoadScene(0);
			}
			else
			{
				gameObject.SetActive(false);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}
}