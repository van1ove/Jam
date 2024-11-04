using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightManager : MonoBehaviour
{
	[SerializeField] private Light2D globalLight;
	[SerializeField] private GameObject timer;

	public void StartFade(float fadeTime)
	{
		StartCoroutine(FadeRoutine(fadeTime));
	}

	private IEnumerator FadeRoutine(float fadeTime)
	{
		float elapsed = 0;
		
		while (elapsed < fadeTime)
		{
			elapsed += Time.deltaTime;
			globalLight.intensity = 1 - elapsed / fadeTime;
			yield return null;
		}
		
		enabled = false;
		globalLight.enabled = false;
	}
}
