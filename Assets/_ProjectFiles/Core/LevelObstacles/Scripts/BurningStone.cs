using UnityEngine;

public class BurningStone : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite nonDamagingSprite;
    [SerializeField] private Sprite damagingSprite;
    [SerializeField] private bool isDamagingByDefault;

    private bool _isDamaging;
    public bool IsDamaging
    {
        get => _isDamaging;
        set
        {
            _isDamaging = value;
            if (value)
            {
                spriteRenderer.sprite = damagingSprite;
            }
            else
            {
                spriteRenderer.sprite = nonDamagingSprite;
            }
        }
    }

    private void Start()
    {
        IsDamaging = isDamagingByDefault;
    }
}
