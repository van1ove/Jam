using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float fullTime;
    [SerializeField] private Slider slider;
    private float remaningTime;
    private bool IsTimerStopped = false;

    private void Start()
    {
        StartCoroutine(TimerWork());
    }

    IEnumerator TimerWork()
    {
        remaningTime = 0;
        slider.value = 0;
        while (IsTimerStopped==false) 
        {
            remaningTime++;
            slider.value = remaningTime / fullTime;
            Debug.Log(remaningTime.ToString());
            yield return new WaitForSeconds(1);
            if (remaningTime >= fullTime)
            {
                IsTimerStopped = true;
            }
        }
        EndTime();
    }

    private void EndTime()
    {
        StopCoroutine(TimerWork());
        Debug.Log("EndTime logic");
    }
}
