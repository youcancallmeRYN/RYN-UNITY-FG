using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealthP2: MonoBehaviour, IDamageable
{
//////////////////////////////////////////////////////////////////////////////////////
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabilityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f; 
    [SerializeField] private Animator _animator;

    public float currentHealth;
    private float  invulnerabilityTimer = 0f ;
    private SpriteRenderer spriteRenderer;
    

    public Slider healthSlider;
     SpriteRenderer sprite;

   [SerializeField] private GameObject BlockParticle;
   [SerializeField] public Transform BlockRef;

   AudioManager audioManager;

   public GameOverLoader GameOver;
    
//////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>(); //GetComponent is a function hence the "()"
        _animator = GetComponent<Animator>();
        BlockParticle.GetComponent<SpriteRenderer>().sortingOrder = 4;
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    

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
         if(Input.GetButton("BlockP2")) //Block Mechanic
         {
            currentHealth -= (amount*-1f); //Damage nulled
            Instantiate(BlockParticle, new Vector2(this.BlockRef.position.x, this.BlockRef.position.y ), Quaternion.identity);
             Debug.Log("BLOCKED!");
             audioManager.PlaySFX(audioManager.BlockSFX);
             //audioManager.PlaySFX(audioManager.BlockSFX);this instantiates alot of particles when not using the code in Awake() FOR NO REASON lolol.
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
        GameOver.gameOver();
    }
}
