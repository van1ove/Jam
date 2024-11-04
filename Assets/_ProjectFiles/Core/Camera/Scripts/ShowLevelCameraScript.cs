using System.Collections;
using Cinemachine;
using UnityEngine;
using System;

public class ShowLevelCameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private float targetCameraSize;
    [SerializeField] private float startCameraSize;
    [SerializeField] private Vector3 startCameraPosition;
    [SerializeField] private AnimationCurve transitionCurve;

    public Action OnShowFinished { get; set; }
    
    private void Awake()
    {
        vcam.Follow = null;
        vcam.transform.position = startCameraPosition;
    }
    
    public void Show(float showTime)
    {
        StartCoroutine(ShowRoutine(showTime));
    }

    private IEnumerator ShowRoutine(float fadeTime)
    {
        var elapsedTime = 0f;
        
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = target.position;
        targetPosition.z = startPosition.z;
        
        float currentCameraSize = startCameraSize;
        
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;

            float normalized = elapsedTime / fadeTime;
            vcam.transform.position = Vector3.Lerp(startCameraPosition, targetPosition, transitionCurve.Evaluate(normalized));
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(currentCameraSize, targetCameraSize, transitionCurve.Evaluate( normalized));
            yield return null;
        }
        
        vcam.transform.position = targetPosition;
        yield return null;
        vcam.Follow = target;
        OnShowFinished?.Invoke();
    }
}
