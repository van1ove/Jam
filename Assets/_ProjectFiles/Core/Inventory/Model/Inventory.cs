using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<InventorySlot> _slots;
    public List<InventorySlot> Slots => _slots;
    
    public Inventory(List<LevelItemInfo> itemsData)
    {
        _slots = new List<InventorySlot>();

        foreach (var data in itemsData)
        {
            var slot = new InventorySlot(data);
            _slots.Add(slot);
        }
    }
    
    public void Add(LevelItemInfo item)
    {
        var itemSlot = _slots.FirstOrDefault(x => x.ItemInfo.ItemId == item.ItemId);
        if (itemSlot != null) itemSlot.AddItem();
    }

    public void Remove(LevelItemInfo item)
    {
        var itemSlot = _slots.FirstOrDefault(x => x.ItemInfo.ItemId == item.ItemId);
        if (itemSlot != null) itemSlot.RemoveItem();
    }
}
