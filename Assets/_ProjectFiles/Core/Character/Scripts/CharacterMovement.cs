using UnityEngine;

public class CharacterMovement
{
	private readonly Rigidbody2D _rigidbody;
	private readonly UserInput _userInput;
	private readonly float _movementSpeed;
	private readonly float _slipDecayRate;
	
	private float _slipSpeed;
	private float _remainingSlipSpeed;
	private Vector2 _lastDirection;

	public CharacterMovement(Rigidbody2D rigidbody, UserInput userInput, float movementSpeed, float slipDecayRate)
	{
		_rigidbody = rigidbody;
		_userInput = userInput;
		_movementSpeed = movementSpeed;
		_slipDecayRate = slipDecayRate;
	}

	public void HandleMovement()
	{
		Vector2 movement = _userInput.Axes * _movementSpeed;

		if (movement != Vector2.zero)
		{
			_lastDirection = movement.normalized;
			_remainingSlipSpeed += _slipSpeed * Time.deltaTime;
		}

		_rigidbody.velocity = (movement * _movementSpeed) + (_lastDirection * _remainingSlipSpeed);

		if (_slipSpeed > 0 && _remainingSlipSpeed != 0)
		{
			_remainingSlipSpeed -= _slipDecayRate * Time.deltaTime;

			if (_remainingSlipSpeed < 0)
			{
				_remainingSlipSpeed = 0;
			}
		}
	}

	public void ApplySlip()
	{
		_slipSpeed = 2;
	}

	public void DiscardSlip()
	{
		_slipSpeed = 0;
		_remainingSlipSpeed = 0;
	}
}