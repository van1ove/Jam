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
        if (_levelItemInfo.ItemId == "water")
        {
            bool hasRaycast = RaycastOnPlace(placePosition, out RaycastHit2D[] result);
            if (!hasRaycast)
            {
                View.ReturnItem();
                return;
            }

            bool hasBurningStone = false;
            
            
            BurningStone stone = new BurningStone();
            foreach (var raycastHit in result)
            {
                hasBurningStone = raycastHit.collider.TryGetComponent(out stone);
                if(stone)
                    hasBurningStone = stone.IsDamaging;
            }

            if (!hasBurningStone)
            {
                View.ReturnItem();
                return;
            }

            stone.IsDamaging = false;
        }
        else
        {
            var lavaItem = Instantiate(lavaItemPrefab, placePosition, Quaternion.identity, null);
            lavaItem.Initialize(_levelItemInfo);
        }
        ItemPlaced?.Invoke();
        
        View.ReturnItem();
    }

    private bool RaycastOnPlace(Vector2 placePosition, out RaycastHit2D[] result)
    {
        var hit = Physics2D.RaycastAll(placePosition, Vector3.forward);
        result = hit;
        
        return hit.Length > 0;
    }

    private void OnDestroy()
    {
        View.OnItemPlaced -= OnItemPlaced;
    }
}