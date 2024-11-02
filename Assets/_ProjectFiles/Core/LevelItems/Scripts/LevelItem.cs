using DG.Tweening;
using UnityEditor.Tilemaps;
using UnityEngine;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LevelItemInfo itemInfo;
    public LevelItemInfo ItemInfo => itemInfo;
    
    private void Start()
    {
        spriteRenderer.sprite = itemInfo.LevelSprite;
        var collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
