using UnityEngine;

public class CharacterTrail : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    
    private void Update()
    {
        transform.position = target.position + offset;
    }
}
