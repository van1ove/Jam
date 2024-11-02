using UnityEngine;

[CreateAssetMenu(menuName = "Items/Level Item Info", fileName = "LevelItemInfo")]
public class LevelItemInfo : ScriptableObject
{
    [SerializeField] private string _itemId;
    [SerializeField] private Sprite _itemSprite;
    [SerializeField] private Sprite _itemIcon;
    
    public string ItemId => _itemId;
    public Sprite ItemSprite => _itemSprite;
    public Sprite ItemIcon => _itemIcon;
}