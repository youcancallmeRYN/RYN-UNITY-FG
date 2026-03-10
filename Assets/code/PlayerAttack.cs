using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 
public class PlayerAttack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    private bool isGrounded;
    private bool isAttacking;
    private Rigidbody2D rb;
    [SerializeField] float damage = 8f;

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Vector2 attackPos = new Vector2(0,0); //Transform
    public float attackRange; //float
    public LayerMask whatIsPlayers;

    public GameObject hitBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            //Attack cooldown
      if(Input.GetButtonDown("AttackP1") && isGrounded)
      {
        Collider2D[] playersToDamage = Physics2D.OverlapCircleAll(hitBox.transform.position, attackRange , whatIsPlayers);
        foreach (Collider2D Gameobject in playersToDamage)
        {
            Debug.Log("Hit!");
        } 
        
      }
      timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

       
      if(_animator)
      {
        _animator.SetBool("isAttacking", isAttacking);
      }
    }

     

    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitBox.transform.position, attackRange);

    }
}
