using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LastCatSceneManager : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private AudioSource playerSource;
	[SerializeField] private AudioSource levelSource;
	private void Awake()
	{
		PlayCatScene();

		playerSource.Stop();
		levelSource.Stop();
	}
	public void PlayCatScene()
	{
		videoPlayer.Play();
	}
}
