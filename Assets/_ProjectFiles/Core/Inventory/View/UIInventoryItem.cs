using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private UIInventoryItemView inventoryItemView;
    private LevelItemInfo _levelItemInfo;
    public UIInventoryItemView View => inventoryItemView;
    
    public void Initialize(LevelItemInfo levelItemInfo)
    {
        inventoryItemView.Initialize(itemImage, levelItemInfo.InventorySprite);
        itemImage.sprite = levelItemInfo.InventorySprite;
        _levelItemInfo = levelItemInfo;
    }
}