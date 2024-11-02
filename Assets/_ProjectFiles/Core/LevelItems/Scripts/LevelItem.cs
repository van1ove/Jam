using UnityEngine;

public class LevelItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LevelItemInfo levelItemInfo;
    
    private void Start()
    {
        spriteRenderer.sprite = levelItemInfo.ItemSprite;
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
