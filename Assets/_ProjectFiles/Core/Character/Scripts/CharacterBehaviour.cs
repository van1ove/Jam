using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private bool isEnabled;
    private List<Collider2D> _currentTriggers;
    public Action<bool> OnCharacterDeath { get; set; }
    public Action OnCharacterDeathAnimationEnd { get; set; }
    
    private bool _isDead;
    private bool _isEnabled;
    private void Start()
    {
        _currentTriggers = new List<Collider2D>();
		StartCoroutine(DelayRoutine());
    }

    private void Update()
    {
        if (!_isEnabled) return;
		if (_isDead) return;
        if (!isEnabled) return;
        
        if (_currentTriggers.Count == 0)
        {
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
    }

	private IEnumerator DelayRoutine()
	{
		yield return new WaitForSeconds(0.5f);
		_isEnabled = true;
		
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