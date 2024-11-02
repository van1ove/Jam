using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _slipDecayRate;

    private CharacterMovement _characterMovement; 
    private Inventory _inventory;
    
    public void Initialize(Inventory inventory)
    {
        _characterMovement = new CharacterMovement(_rigidbody, _userInput, _movementSpeed, _slipDecayRate);
        _inventory = inventory;
    }

    private void Update()
    {
        _characterMovement.HandleMovement();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("IceCube"))
        {
            _characterMovement.ApplySlip();
        }

        if (other.TryGetComponent(out LevelItem item))
        {
            _inventory.Add(item.ItemInfo);
            item.Collect();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("IceCube"))
        {
            _characterMovement.DiscardSlip();
        }
    }
}