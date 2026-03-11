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
    public Vector2 attackPos = new Vector2(0, 0); //Transform
    public float attackRange; //float
    public LayerMask whatIsPlayers;
    public GameObject hitBox;
    private bool canAttack = true;

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
        if (spriteRenderer != null)
        {
            if (horizInput > 0.1f) hitBox.transform.localScale = new Vector3 (1,1,1);
            else if (horizInput < -0.1f) hitBox.transform.localScale = new Vector3 (-1,1,1);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("AttackP1") && canAttack)
        {
            _animator.SetBool("isAttacking", true);
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
        else
        {
            _animator.SetBool("isAttacking", false);
        }



        // Debug.Log(timeBtwAttack);

        // if (canAttack == true) {}
        // if (timeBtwAttack <= 0)
        // {
        //Attack cooldown
        // if (Input.GetButton("AttackP1") && canAttack == true)
        // {




        // }
        // timeBtwAttack = startTimeBtwAttack;
        // }
        // else
        // {
        //     timeBtwAttack -= Time.deltaTime;
        // }


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
