using UnityEngine;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LevelItemInfo itemInfo;
    [SerializeField] private ConfigurableEffect pickUpEffect;
    public LevelItemInfo ItemInfo => itemInfo;
    
    private void Start()
    {
        spriteRenderer.sprite = itemInfo.LevelSprite;
        var collider = gameObject.AddComponent<PolygonCollider2D>();
        collider.isTrigger = true;
    }

    public void Collect()
    {
        var effect = Instantiate(pickUpEffect, transform.position, Quaternion.identity, null);
        effect.Play(true);
        
        Destroy(gameObject);
    }
}
