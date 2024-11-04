using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigidbody;
	[SerializeField] private UserInput userInput;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float slipDecayRate;
	[SerializeField] private float slipSpeed;
	private SoundsManager soundsManager;
	
	private float _slipSpeed;
	private float _remainingSlipSpeed;
	private Vector2 _lastDirection;

	public bool Enabled
	{
		get => _enabled;
		set
		{
			_enabled = value;
			if (!_enabled)
			{
				rigidbody.velocity = Vector2.zero;
			}
		}
	}

	private bool _enabled;
	
	public Vector2 Velocity => rigidbody.velocity + _lastDirection * _remainingSlipSpeed;

	private void Awake() => soundsManager = SoundsManager.Instance;

	private void Update()
	{
		if (!Enabled) return;
		
		HandleMovement();
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("IceCube"))
		{
			ApplySlip();
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("IceCube"))
		{
			DiscardSlip();
		}
	}
	
	public void HandleMovement()
	{
		Vector2 movement = userInput.Axes * movementSpeed;

		if (movement != Vector2.zero)
		{
			_lastDirection = movement.normalized;
			_remainingSlipSpeed += _slipSpeed * Time.deltaTime;

			PlayWalkingSound();
		}
		else
		{
			StopWalkingSound();
		}

		rigidbody.velocity = (movement * movementSpeed) + (_lastDirection * _remainingSlipSpeed);

		if (_slipSpeed > 0 && _remainingSlipSpeed != 0)
		{
			_remainingSlipSpeed -= slipDecayRate * Time.deltaTime;

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
	private void PlayWalkingSound()
	{
		if (!soundsManager.IsPlaying())
		{
			soundsManager.PlayClip("walking-squidward");
		}
	}

	private void StopWalkingSound()
	{
		soundsManager.StopClip();
	}
}