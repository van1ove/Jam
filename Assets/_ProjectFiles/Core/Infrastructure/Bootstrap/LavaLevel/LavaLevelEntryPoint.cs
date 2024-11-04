using System.Collections.Generic;
using UnityEngine;

public class LavaLevelEntryPoint : MonoBehaviour
{
    [SerializeField] private UIInventory inventoryView;
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private CharacterMovement characterMovement;

    private void Start()
    {
        characterMovement.Enabled = true;
        //inventoryView.Initialize();
    }
}