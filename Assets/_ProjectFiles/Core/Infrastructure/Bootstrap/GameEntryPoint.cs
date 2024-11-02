using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private UIInventory inventoryView;
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private CharacterContainer characterContainer;

    private void Start()
    {
        var inventory = new Inventory(itemInfos);
        
        characterContainer.Initialize(inventory);
        inventoryView.Initialize(inventory);
    }
}