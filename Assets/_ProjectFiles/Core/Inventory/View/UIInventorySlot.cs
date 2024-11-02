using TMPro;
using UnityEngine;

public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private TMP_Text itemCountText;
    [SerializeField] private Transform itemContent;
    [SerializeField] private UIInventoryItem item;
    private InventorySlot _slot;
    
    public void Initialize(InventorySlot slot)
    {
        _slot = slot;
        _slot.OnItemChanged += OnInventorySlotChanged;
        item.Initialize(slot.ItemInfo);
        
        UpdateSlot();
    }

    private void UpdateSlot()
    {
        itemCountText.text = _slot.ItemCount.ToString();

        if (_slot.ItemCount == 0)
        {
            item.Disable();
        }
        else
        {
            item.Enable();
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