using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float fullTime;
    [SerializeField] private Slider slider;
    private float remainingTime = 0;
    private float sliderValue = 0;
    private bool isTimerStopped = false;
    private bool isPaused = false;

    private void Start()
    {
        StartCoroutine(TimerWork());
        GameManager.onPlayerDied += StopCorutine;
        GameManager.onPlayerWin += StopCorutine;
        GameManager.onPause += PauseCorotine;
    }

    IEnumerator TimerWork()
    {
       // remainingTime = 0;
       // slider.value = 0;
        while (!isTimerStopped)
        {
            remainingTime++;
            sliderValue = remainingTime / fullTime;
            yield return StartCoroutine(UpdateSliderValue(slider.value, remainingTime / fullTime));
            yield return new WaitForSeconds(1);
            if (remainingTime >= fullTime)
            {
                isTimerStopped = true;
            }
        }
        yield return new WaitForSeconds(2);
        EndTime();
    }
    private IEnumerator UpdateSliderValue(float startValue, float targetValue)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            slider.value = Mathf.Lerp(startValue, targetValue, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        slider.value = targetValue;
    }

    private void EndTime()
    {
        StopCoroutine(TimerWork());
        GameManager.onTimeOver?.Invoke();
    }

    private void StopCorutine()
    {
        GameManager.onPlayerDied -= StopCorutine;
        GameManager.onPlayerWin -= StopCorutine;
        StopCoroutine(TimerWork());
    }

    private void PauseCorotine()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(TimerWork());
        }
    }
}
