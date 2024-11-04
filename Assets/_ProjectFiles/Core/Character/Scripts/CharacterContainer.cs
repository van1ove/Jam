using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterRenderer characterRenderer;
    [SerializeField] private CharacterBehaviour characterBehaviour;
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private bool is2ndStage;
    public Inventory _inventory { get; set; }

    private void Start()
    {
        if (is2ndStage)
        {
            transform.position = startPosition;
        }
    }
    
    public void Initialize(Inventory inventory)
    {
        characterBehaviour.OnCharacterDeath += OnCharacterDeath;
        characterBehaviour.OnCharacterWin += OnPlayerWin;
        _inventory = inventory;

        soundsManager = SoundsManager.Instance;
        Debug.Log("initialized");
    }

    private void OnPlayerWin()
    {
        characterMovement.Enabled = false;
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