using UnityEngine;

public class PlayerMovementWASD : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator _animator; 
    public float speed = 8f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.12f;
    public Vector2 groundCheckOffset = new Vector2(0f, -0.5f);
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float horizInput;
    private bool isGrounded;

    AudioManager audioManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        horizInput = Input.GetAxisRaw("Horizontal1");

        Vector2 rayOrigin = groundCheck != null ? (Vector2)groundCheck.position : (Vector2)transform.position + groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null; 

        if (_animator)
        {
            _animator.SetFloat("horizInput", Mathf.Abs(horizInput));
            _animator.SetBool("isGrounded", isGrounded);
        }
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioManager.PlaySFX(audioManager.jumpSFX);
        }


        if (spriteRenderer != null)
        {
            if (horizInput > 0.1f) spriteRenderer.flipX = false;
            else if (horizInput < -0.1f) spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizInput * speed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position + (Vector3)groundCheckOffset, transform.position + (Vector3)groundCheckOffset + Vector3.down * groundCheckDistance);
        }
    }
}