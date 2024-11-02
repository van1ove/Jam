using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private UIInventorySlot uiInventorySlot;
    [SerializeField] private RectTransform slotsContent;
    
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