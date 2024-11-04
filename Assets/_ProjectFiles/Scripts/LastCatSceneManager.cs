using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LastCatSceneManager : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;
	private void Awake()
	{
		PlayCatScene();
	}
	public void PlayCatScene()
	{
		videoPlayer.Play();
	}
}
