using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRising : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer; 
	[SerializeField] private float fadeDuration = 2f;

	private void Awake()
	{
		GameManager.onTimeOver += OnTimeOver;
	}

	private void OnTimeOver()
	{
		StartCoroutine(FadeInSprite());
	}

	private IEnumerator FadeInSprite()
	{
		Color color = spriteRenderer.color;
		color.a = 0;
		spriteRenderer.color = color;

		float elapsedTime = 0f;

		while (elapsedTime < fadeDuration)
		{
			elapsedTime += Time.deltaTime;
			color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
			spriteRenderer.color = color;
			yield return null;
		}

		color.a = 1f;
		spriteRenderer.color = color;

		GameManager.onTimeOver -= OnTimeOver;
	}
}
