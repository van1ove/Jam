using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] clips;
	
	public void PlayClip(string clipName)
	{
		foreach (AudioClip clip in clips)
		{
			if (clipName == clip.name)
			{
				audioSource.PlayOneShot(clip);
				Debug.Log(clip.name);
			}
		}
	}
}
