using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlackboard : MonoBehaviour
{
    [SerializeField] private float runVelocity = 7.0f;
    [SerializeField] private float jumpVelocity = 15.0f;
    [SerializeField] private float groundCheckDistance = 0.3f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private Animator playerAnimator;

    public Rigidbody2D Body { get; private set; }
    public PlayerControls PlayerControls { get; private set; }
    public bool IsGrounded { get; set; }

    public float RunVelocity => runVelocity;
    public float JumpVelocity => jumpVelocity;
    public Animator PlayerAnimator => playerAnimator;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        PlayerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        PlayerControls.Enable();
    }

    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    public void CheckIfGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (groundPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundPoint.position, groundCheckDistance);
        }
    }
}