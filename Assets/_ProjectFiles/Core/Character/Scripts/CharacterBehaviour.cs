using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private bool isEnabled;
    private List<Collider2D> _currentTriggers;

    private void Start()
    {
        _currentTriggers = new List<Collider2D>();
    }

    private void Update()
    {
        if (!isEnabled) return;
        
        if (_currentTriggers.Count == 0)
        {
            Debug.Log("Death");
        }
        else
        {
            //Debug.Log($"Current tirggers count: {_currentTriggers.Count}");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentTriggers.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currentTriggers.Remove(other);
    }
}