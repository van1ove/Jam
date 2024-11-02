using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private float _movementSpeed;

    private CharacterMovement _characterMovement; 
    
    private void Start()
    {
        _characterMovement = new CharacterMovement(_rigidbody, _userInput, _movementSpeed);
    }

    private void Update()
    {
        _characterMovement.HandleMovement();
    }
}