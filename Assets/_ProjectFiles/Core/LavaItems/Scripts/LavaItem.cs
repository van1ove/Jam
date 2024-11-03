using UnityEngine;
using UnityEngine.UI;

public class LavaItem : MonoBehaviour
{
    [SerializeField] private ConfigurableEffect placeEffect;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        var effect = Instantiate(placeEffect, transform.position, Quaternion.identity, transform);
        effect.Play(true);
    }

    public void Initialize(LevelItemInfo levelItemInfo)
    {
        spriteRenderer.sprite = levelItemInfo.LevelSprite;
        var trigger = gameObject.AddComponent<PolygonCollider2D>();
        trigger.isTrigger = true;
    }
}