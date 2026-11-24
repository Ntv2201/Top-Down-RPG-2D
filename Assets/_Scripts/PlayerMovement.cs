using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    float horizontal;
    float vertical;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        HandleAnimation();
        HandleFlip();
        
    }

    private void FixedUpdate()
    {
        HandleMovement();

    }

    private void HandleMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(horizontal, vertical).normalized * moveSpeed;
    }

    private void HandleAnimation()
    {
        animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("vertical", Mathf.Abs(vertical));
    }

    private void HandleFlip()
    {
        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
    }


}
