using System.Collections.Generic;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private UIInventory inventoryView;
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private CharacterContainer characterContainer;
    //[SerializeField] private GameStartScript gameStartScript;
    
    private void Awake()
    {
        var inventory = new Inventory(itemInfos);
        
        characterContainer.Initialize(inventory);
        inventoryView.Initialize(inventory);
        
        GameManager.onTimeOver = null;
        GameManager.onContinueGame = null;
        GameManager.onPause = null;
        GameManager.onPlayerWin = null;
        GameManager.onPlayerDied = null;
        
        //gameStartScript.StartGame();
    }
}
