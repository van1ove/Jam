using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private bool isEnabled;
    private List<Collider2D> _currentTriggers;
    public Action<bool> OnCharacterDeath { get; set; }
    public Action OnCharacterDeathAnimationEnd { get; set; }
    public Action OnCharacterWin { get; set; }
    
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
            Debug.Log("trigger 0");
            _isDead = true;
            OnCharacterDeath?.Invoke(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentTriggers.Add(other);

        if (other.TryGetComponent(out BurningStone stone))
        {
            if (stone.IsDamaging)
            {
                OnCharacterDeath?.Invoke(false);
                _isDead = true;
            }
        }

        if (other.TryGetComponent(out WinTrigger trigger))
        {
            OnCharacterWin?.Invoke();
        }
    }

    public void OnDeathAnimationEnd()
    {
        OnCharacterDeathAnimationEnd?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _currentTriggers.Remove(other);
    }
}