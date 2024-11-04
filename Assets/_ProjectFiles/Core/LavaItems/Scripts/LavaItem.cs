using UnityEngine;
using UnityEngine.UI;

public class LavaItem : MonoBehaviour
{
    [SerializeField] private ConfigurableEffect placeEffect;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private SoundsManager soundsManager;

    private void Start()
    {
        var effect = Instantiate(placeEffect, transform.position, Quaternion.identity, transform);
        effect.Play(true);
    }

    public void Initialize(LevelItemInfo levelItemInfo)
    {
        spriteRenderer.sprite = levelItemInfo.LavaSprite;
        var trigger = gameObject.AddComponent<PolygonCollider2D>();
        trigger.isTrigger = true;

        soundsManager = SoundsManager.Instance;

        if (levelItemInfo.ItemId == "ice" || levelItemInfo.ItemId == "water")
        {
            soundsManager.PlayClip("steam-hiss");
        }
        else 
        {
            soundsManager.PlayClip("drop-item-on-lava");
		}
    }
}