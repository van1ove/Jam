using System.Collections.Generic;
using UnityEngine;

public class LavaLevelEntryPoint : MonoBehaviour
{
    [SerializeField] private UIInventory inventoryView;
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterContainer characterContainer;

    private void Start()
    {
        characterMovement.Enabled = true;
        inventoryView.Initialize(GameManager.CurrentInventory);
        characterContainer.Initialize(GameManager.CurrentInventory);
        inventoryView.Interactable(true);
    }
}