using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightManager : MonoBehaviour
{
	[SerializeField] private Light2D globalLight;

	private const float lightOffDelay = 5f;

	private float decreaseRate;
	private float targetValue;

	private void Awake()
	{
		decreaseRate = 0.3f;
		targetValue = 1f;

		Invoke(nameof(StartLightOffTimer), 5f);
	}

	private void Update()
	{
		if (globalLight.intensity > targetValue)
		{
			globalLight.intensity -= decreaseRate * Time.deltaTime;

			if (globalLight.intensity < targetValue)
			{
				globalLight.intensity = targetValue;
			}
		}
		else if (targetValue <= 0)
		{
			this.enabled = false;
			globalLight.enabled = false;
		}
	}
	private void StartLightOffTimer()
	{
		targetValue = 0f;
	}
}
