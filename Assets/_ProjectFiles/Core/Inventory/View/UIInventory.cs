using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIInventorySlot uiInventorySlot;
    [SerializeField] private RectTransform slotsContent;
    
    private List<UIInventorySlot> _slots = new List<UIInventorySlot>();
    private Inventory _inventory;
    
    
    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
        
        foreach (var inventorySlot in _inventory.Slots)
        {
            var slot = Instantiate(uiInventorySlot, slotsContent);
            _slots.Add(slot);
            
            slot.Initialize(inventorySlot);
        }
    }

    public void Interactable(bool value)
    {
        _slots.ForEach(slot => slot.Interactable = value);
    }
}