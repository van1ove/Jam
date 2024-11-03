using System.Collections;
using UnityEngine;

public class ConfigurableEffect : MonoBehaviour
{
    [SerializeField] private float effectScale;
    [SerializeField] private float playDuration;
    [SerializeField] private float stopDuration;
    [SerializeField] private ParticleSystem parentSystem; 
    [SerializeField] private bool playOnAwake;

    private void Start()
    {
        if (effectScale == 0) effectScale = 1;
        transform.localScale = Vector3.one * effectScale;
    }
    
    public void Play(bool destroyAfter)
    {
        if (destroyAfter)
        {
            StartCoroutine(PlayRoutine(playDuration));
        }
    }

    public void Stop(bool destroyAfter)
    {
        parentSystem.Stop(true);

        if (destroyAfter)
        {
            StartCoroutine(PlayRoutine(stopDuration));
        }
    }

    private IEnumerator PlayRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
