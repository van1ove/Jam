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
    [SerializeField] private Vector2 startCameraPosition;
    [SerializeField] private float transitionDuration;

    public Action OnShowFinished { get; set; }
    
    private void Start()
    {
        vcam.transform.position = startCameraPosition;
    }
    
    public void Show()
    {
        StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        var elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        
        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(startPosition, target.transform.position, elapsedTime / transitionDuration);
            
            yield return null;
        }
        
        vcam.Follow = target;
        OnShowFinished?.Invoke();
    }
}
