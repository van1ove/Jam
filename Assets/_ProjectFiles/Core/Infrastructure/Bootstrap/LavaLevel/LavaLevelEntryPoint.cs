using System.Collections.Generic;
using UnityEngine;

public class LavaLevelEntryPoint : MonoBehaviour
{
    [SerializeField] private UIInventory inventoryView;
    [SerializeField] private List<LevelItemInfo> itemInfos;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterContainer characterContainer;
    [SerializeField] private CharacterBehaviour characterBehaviour;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Timer timer;

    private void Start()
    {
        characterMovement.Enabled = true;
        inventoryView.Initialize(GameManager.CurrentInventory);
        characterContainer.Initialize(GameManager.CurrentInventory);
        inventoryView.Interactable(true);
        
        characterBehaviour.OnCharacterDeathAnimationEnd += OnCharacterDeathAnimationEnd;
        characterBehaviour.OnCharacterWin += OnCharacterWin;
    }

    private void OnCharacterDeathAnimationEnd()
    {
        loseScreen.gameObject.SetActive(true);
        timer.gameObject.SetActive(false);
    }

    private void OnCharacterWin()
    {
        winScreen.gameObject.SetActive(true);
        timer.gameObject.SetActive(false);
    }
}