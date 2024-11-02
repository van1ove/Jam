using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Items/Level Item Info", fileName = "LevelItemInfo")]
public class LevelItemInfo : ScriptableObject
{
    [SerializeField] private string itemId;
    [SerializeField] private Sprite levelSprite;
    [SerializeField] private Sprite inventorySprite;
    
    public string ItemId => itemId;
    public Sprite LevelSprite => levelSprite;
    public Sprite InventorySprite => inventorySprite;
}