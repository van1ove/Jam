using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private UIInventorySlot uiInventorySlot;
    [SerializeField] private Transform slotsContent;
    
    private Inventory _inventory;
    
    private void Start()
    {
        _inventory = new Inventory(itemInfos);

        foreach (var inventorySlot in _inventory.Slots)
        {
            var slot = Instantiate(uiInventorySlot, slotsContent);
            uiInventorySlot.Initialize(inventorySlot);
        }
    }
}