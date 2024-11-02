using System;

public class InventorySlot
{
    private LevelItemInfo _itemInfo;
    public LevelItemInfo ItemInfo => _itemInfo;
    public int ItemCount { get; private set; }
    public Action OnItemChanged { get; set; }

    public InventorySlot(LevelItemInfo itemInfo)
    {
        _itemInfo = itemInfo;
    }

    public void AddItem()
    {
        ItemCount++;
        OnItemChanged?.Invoke();
    }

    public void RemoveItem()
    {
        ItemCount--;
        OnItemChanged?.Invoke();
    }
}