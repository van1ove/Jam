using UnityEngine;

public class CharacterMovement
{
    private Rigidbody2D _rigidbody;
    private UserInput _userInput;
    private float _movementSpeed;
    
    public CharacterMovement(Rigidbody2D rigidbody, UserInput userInput, float movementSpeed)
    {
        _rigidbody = rigidbody;
        _userInput = userInput;
        _movementSpeed = movementSpeed;
    }

    public void HandleMovement()
    {
        _rigidbody.velocity = _userInput.Axes * _movementSpeed;
    }
}