using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Animator animator;
    private Vector3 _currentScale;
    
    private void Start()
    {
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
            
            Debug.Log(direction);
        }
    }
}