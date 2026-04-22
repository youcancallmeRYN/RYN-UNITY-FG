using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth: MonoBehaviour, IDamageable
{
//////////////////////////////////////////////////////////////////////////////////////
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabilityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f; 
    [SerializeField] private Animator _animator;

    public float currentHealth;
    private float  invulnerabilityTimer = 0f ;
    private SpriteRenderer spriteRenderer;
    //private SpriteRenderer BlockParticle;

    public Slider healthSlider;

    SpriteRenderer sprite;
    //SpriteRenderer blockVFX;

    
//////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>(); //GetComponent is a function hence the "()"
        _animator = GetComponent<Animator>();
        //blockVFX = GetComponent<BlockParticle>();

        //blockVFX.enabled = false;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

    }
    void Update()
    {
        if(invulnerabilityTimer > 0f )
        {
            invulnerabilityTimer-=Time.deltaTime; //countdown code

        }
         if(currentHealth < maxHealth)
        {
            maxHealth = currentHealth;
            _animator.SetBool("isHurt", true);
        }
        else
        {
            _animator.SetBool("isHurt", false);
        }
        
    }
    //////////////////////////////////////////////////////////////////////////////////////
    public bool ApplyDamage(float amount) // from IDamageable function
    {
        if(currentHealth <=0f || invulnerabilityTimer > 0f)
             return false;
    
        currentHealth -= amount;
         if(Input.GetButton("BlockP1")) //Block Mechanic
         {
            currentHealth -= (amount*-1f); //Damage chipped
             Debug.Log("BLOCKED!");
             //blockVFX.enabled = true;
         }
         if(Input.GetButton("BlockP2")) //Block Mechanic
         {
            currentHealth -= (amount*-1f); //Damage chipped
             Debug.Log("BLOCKED!");
             //blockVFX.enabled = true;
             
         }

        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if(currentHealth <= 0f)
        {
            Die();
            return true;

        }
        invulnerabilityTimer = invulnerabilityDuration;
        return true;
    }
//////////////////////////////////////////////////////////////////////////////////////
    void Die()
    {
        gameObject.SetActive(false);
    }
}