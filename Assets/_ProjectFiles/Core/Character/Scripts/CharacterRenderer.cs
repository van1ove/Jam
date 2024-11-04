using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
	private static readonly int IsMoving = Animator.StringToHash("IsMoving");
	private static readonly int IsOtherIdle = Animator.StringToHash("IsOtherIdle");
	private static readonly int Death = Animator.StringToHash("DeathOption");
	[SerializeField] private CharacterMovement characterMovement;
	[SerializeField] private Animator animator;

	[Header("Lights")] [SerializeField] private bool lightEnabled = true;
	[SerializeField] private GameObject light;
	[SerializeField] private GameObject candle;
	private Vector3 _currentScale;
	private bool _isIdleChanged;
	
	private void Start()
	{
		light.SetActive(lightEnabled);
		candle.SetActive(lightEnabled);
		_currentScale = transform.localScale;
	}

	private void Update()
	{
		bool isMoving = characterMovement.Velocity.magnitude > 0;
		bool isOtherIdle = animator.GetBool(IsOtherIdle);
		
		animator.SetBool(IsMoving, isMoving);

		if (isMoving)
		{
			var direction = characterMovement.Velocity.x > 0 ? 1 : -1;
			_currentScale.x = direction;
			transform.localScale = _currentScale;

			_isIdleChanged = false;
		}
		else if (!_isIdleChanged)
		{
			_isIdleChanged = true;
			animator.SetBool(IsOtherIdle, !isOtherIdle);
		}
	}

	public void OnDeath(bool isDeathFromLava)
	{
		characterMovement.enabled = false;

		if (isDeathFromLava)
		{
			animator.SetInteger(Death, 0);        
		}
		else
		{
			int randomNumber = Random.Range(1, 3);
			animator.SetInteger(Death, randomNumber);
		}
	}
}