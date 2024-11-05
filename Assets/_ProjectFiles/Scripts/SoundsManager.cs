using UnityEngine;

public class SoundsManager : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] clips;
	[SerializeField] private string lastClipsName;

	public static SoundsManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			//DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void PlayClip(string clipName)
	{
		
		audioSource.Stop();
		foreach (AudioClip clip in clips)
		{
			if (clipName == clip.name)
			{
				audioSource.PlayOneShot(clip);
				lastClipsName = clip.name;
			}
		}
	}
	public bool IsPlaying()
	{
		return audioSource.isPlaying;
	}

	public void StopClip()
	{
		if (audioSource.isPlaying && lastClipsName == "walking-squidward")
		{
			audioSource.Stop();
		}
	}
}