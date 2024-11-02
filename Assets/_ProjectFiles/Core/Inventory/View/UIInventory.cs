using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIInventorySlot uiInventorySlot;
    [SerializeField] private RectTransform slotsContent;
    
    private Inventory _inventory;
    
    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
        
        foreach (var inventorySlot in _inventory.Slots)
        {
            var slot = Instantiate(uiInventorySlot, slotsContent);
            
            slot.Initialize(inventorySlot);
        }
    }
}