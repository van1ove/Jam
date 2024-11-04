using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private bool isEnabled;
    private List<Collider2D> _currentTriggers;
    public Action OnCharacterDeath { get; set; }
    
    private bool _isDead;
    private void Start()
    {
        _currentTriggers = new List<Collider2D>();
    }

    private void Update()
    {
        if (_isDead) return;
        if (!isEnabled) return;
        
        if (_currentTriggers.Count == 0)
        {
            _isDead = true;
            OnCharacterDeath?.Invoke(); // lava
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentTriggers.Add(other);

        if (other.TryGetComponent(out BurningStone stone))
        {
            if (stone.IsDamaging)
            {
                OnCharacterDeath?.Invoke(); //other
                _isDead = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currentTriggers.Remove(other);
    }
}