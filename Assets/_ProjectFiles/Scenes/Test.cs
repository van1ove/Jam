using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private List<LevelItemInfo> levelItems;
    
    private void Awake()
    {
        var inventory = new Inventory(levelItems);
        inventory.Slots.ForEach(x => x.AddItem());
        
        GameManager.CurrentInventory = inventory;
    }
}
