using UnityEngine;

public class LavaItem : MonoBehaviour
{
    [SerializeField] private ConfigurableEffect placeEffect;

    private void Start()
    {
        var effect = Instantiate(placeEffect, transform.position, Quaternion.identity, transform);
        effect.Play(true);
    }
}