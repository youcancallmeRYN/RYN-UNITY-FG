using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerAttackP1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator _animator;
    private bool isGrounded;
    private bool isAttacking;
    private Rigidbody2D rb;
    [SerializeField] float damage = 8f;
    private float horizInput;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Vector2 attackPos = new Vector2(0, 0); 
    public float attackRange; 
    public LayerMask whatIsPlayers;
    public GameObject hitBox;
    private bool canAttack = true;
    private bool facingRight = true; // Player 1 start facing right, hence true

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        //to flip hitboxes when facing the appropriate directions
        horizInput = Input.GetAxisRaw("Horizontal1");
            if (horizInput > 0.1f && !facingRight) 
            {
               Flip();
            }
            else if (horizInput < -0.1f && facingRight)
            {
                Flip();
            }

        if (Input.GetButton("AttackP1") && canAttack)
        {
            _animator.SetBool("isAttacking", true);
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }
    }
    void Flip()
    {
        Vector3 currentScale = hitBox.transform.localScale;
        currentScale.x *= -1;
        hitBox.transform.localScale = currentScale;
        facingRight = !facingRight;
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("AttackP1") && canAttack)
        {
            Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(hitBox.transform.position, attackRange, whatIsPlayers);

            foreach (Collider2D Gameobject in playersToDamage)
            {
                if (other.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(damage);
                    Debug.Log("Hit!");
                    StartCoroutine(AttackCooldown());
                }
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        Debug.Log("Cooldown Start");
        _animator.SetBool("isAttacking", false);
        canAttack = false;
        yield return new WaitForSeconds(startTimeBtwAttack);
        canAttack = true;
        Debug.Log("Cooldown Finish");

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitBox.transform.position, attackRange);

    }
}
