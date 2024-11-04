using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterRenderer characterRenderer;
    [SerializeField] private CharacterBehaviour characterBehaviour;
    [SerializeField] private SoundsManager soundsManager;
    private Inventory _inventory;
    
    public void Initialize(Inventory inventory)
    {
        characterBehaviour.OnCharacterDeath += OnCharacterDeath;
        _inventory = inventory;

        soundsManager = SoundsManager.Instance;
    }

    private void OnCharacterDeath(bool isDeathFromLava)
    {
        characterMovement.Enabled = false;
        characterRenderer.OnDeath(isDeathFromLava);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out LevelItem item))
        {
            _inventory.Add(item.ItemInfo);
            item.Collect();

            soundsManager.PlayClip("grab-item");
        }
    }

    private void OnDestroy()
    {
        characterBehaviour.OnCharacterDeath -= OnCharacterDeath;
    }
}