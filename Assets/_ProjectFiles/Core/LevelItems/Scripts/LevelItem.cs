using UnityEngine;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LevelItemInfo itemInfo;
    public LevelItemInfo ItemInfo => itemInfo;
    
    
    private void Start()
    {
        spriteRenderer.sprite = itemInfo.ItemSprite;
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
