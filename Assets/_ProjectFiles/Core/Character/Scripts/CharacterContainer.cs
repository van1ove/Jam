using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterRenderer characterRenderer;
    [SerializeField] private CharacterBehaviour characterBehaviour;
    private Inventory _inventory;
    
    public void Initialize(Inventory inventory)
    {
        characterBehaviour.OnCharacterDeath += OnCharacterDeath;
        _inventory = inventory;
    }

    private void OnCharacterDeath()
    {
        characterMovement.Enabled = false;
        characterRenderer.OnDeath();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out LevelItem item))
        {
            _inventory.Add(item.ItemInfo);
            item.Collect();
        }
    }

    private void OnDestroy()
    {
        characterBehaviour.OnCharacterDeath -= OnCharacterDeath;
    }
}