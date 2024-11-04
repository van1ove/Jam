using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Death = Animator.StringToHash("Death");
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Animator animator;

    [Header("Lights")] [SerializeField] private bool lightEnabled = true;
    [SerializeField] private GameObject light;
    [SerializeField] private GameObject candle;
    private Vector3 _currentScale;
    
    private void Start()
    {
        light.SetActive(lightEnabled);
        candle.SetActive(lightEnabled);
        _currentScale = transform.localScale;
    }

    private void Update()
    {
        bool isMoving = characterMovement.Velocity.magnitude > 0;
        
        animator.SetBool(IsMoving, isMoving);

        if (isMoving)
        {
            var direction = characterMovement.Velocity.x > 0 ? 1 : -1;
            _currentScale.x = direction;
            transform.localScale = _currentScale;
        }
    }

    public void OnDeath()
    {
        animator.SetTrigger(Death);
    }
}