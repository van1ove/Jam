using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float fullTime;
    [SerializeField] private Slider slider;
    [SerializeField] private bool takeItemLvl;
    [SerializeField] private int delayStart;
    private float remainingTime = 0;
    private float sliderValue = 0;
    private bool isTimerStopped = false;

    private void Start()
    {
        StartCoroutine(TimerWork());
        GameManager.onPlayerDied += StopCorutine;
        GameManager.onPlayerWin += StopCorutine;
        GameManager.onPause += PauseCorotine;
        GameManager.onContinueGame += ContinueCorotine;
    }

    IEnumerator TimerWork()
    {
        if(delayStart>0)
        {
            yield return new WaitForSeconds(delayStart);
            delayStart = 0;
        }

        while (!isTimerStopped)
        {
            yield return new WaitForSeconds(1);
            remainingTime++;
            sliderValue = remainingTime / fullTime;

            yield return StartCoroutine(UpdateSliderValue(slider.value, sliderValue));

            if (remainingTime >= fullTime)
            {
                isTimerStopped = true;
            }

        }
        if(takeItemLvl)
        {
            GameManager.onTeleportPlayer?.Invoke();
        } 
        else
        {
            EndTime();
        }
       
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
        gameObject.SetActive(false);
        StopCoroutine(TimerWork());
    }

    private void PauseCorotine()
    {
        StopAllCoroutines();
    }
    private void ContinueCorotine()
    {
        StartCoroutine(TimerWork());
    }
}
