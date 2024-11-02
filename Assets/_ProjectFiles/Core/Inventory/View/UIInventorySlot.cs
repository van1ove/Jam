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
    }

    private void OnInventorySlotChanged()
    {
        itemCountText.text = _slot.ItemCount.ToString();
    }

    private void OnDestroy()
    {
        if (_slot != null) _slot.OnItemChanged -= OnInventorySlotChanged;
    }
}