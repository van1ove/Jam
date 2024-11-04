using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private Transform itemContent;
    [SerializeField] private UIInventoryItem item;
    private InventorySlot _slot;

    public bool Interactable
    {
        get => item.Interactable;
        set => item.Interactable = value;
    }
    
    public void Initialize(InventorySlot slot)
    {
        _slot = slot;
        _slot.OnItemChanged += OnInventorySlotChanged;
        item.ItemPlaced += ItemPlaced;
        
        item.Initialize(slot.ItemInfo);
        
        UpdateSlot();
    }

    private void ItemPlaced()
    {
        _slot.RemoveItem();  
        UpdateSlot();
    }
    
    private void UpdateSlot()
    {
        itemCountText.text = _slot.ItemCount.ToString();

        if (_slot.ItemCount == 0)
        {
            item.View.Disable();
        }
        else
        {
            item.View.Enable();
        }
    }
    
    private void OnInventorySlotChanged()
    {
        UpdateSlot();
    }

    private void OnDestroy()
    {
        if (_slot != null) _slot.OnItemChanged -= OnInventorySlotChanged;
    }
}