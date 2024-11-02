using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    private Inventory _inventory;
    
    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out LevelItem item))
        {
            _inventory.Add(item.ItemInfo);
            item.Collect();
        }
    }
}