using System;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private UIInventoryItemView inventoryItemView;
    [SerializeField] private LavaItem lavaItemPrefab;
    private LevelItemInfo _levelItemInfo;
    public UIInventoryItemView View => inventoryItemView;
    public Action ItemPlaced { get; set; }

    public bool Interactable
    {
        get => View.Interactable;
        set => View.Interactable = value;
    }
    
    private void Start()
    {
        View.OnItemPlaced += OnItemPlaced;
    }

    public void Initialize(LevelItemInfo levelItemInfo)
    {
        inventoryItemView.Initialize(itemImage, levelItemInfo.InventorySprite);
        itemImage.sprite = levelItemInfo.InventorySprite;
        _levelItemInfo = levelItemInfo;
    }

    private void OnItemPlaced(Vector2 placePosition)
    {
        var lavaItem = Instantiate(lavaItemPrefab, placePosition, Quaternion.identity, null);
        lavaItem.Initialize(_levelItemInfo);
        ItemPlaced?.Invoke();
        
        View.ReturnItem();
    }

    private bool RaycastOnPlace(Vector2 placePosition, out RaycastHit[] result)
    {
        var hit = Physics.RaycastAll(placePosition, Vector3.forward);
        result = hit;
        
        if (hit.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDestroy()
    {
        View.OnItemPlaced -= OnItemPlaced;
    }
}