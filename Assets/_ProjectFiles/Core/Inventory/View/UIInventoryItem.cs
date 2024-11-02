using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    private LevelItemInfo _levelItemInfo;
    
    public void Initialize(LevelItemInfo levelItemInfo)
    {
        itemImage.sprite = levelItemInfo.ItemIcon;
        _levelItemInfo = levelItemInfo;
    }
}