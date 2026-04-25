using UnityEngine;

public class PlayerBlockP1 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.SetBool("isBlocking", false);
        _animator.SetBool("isGrounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("BlockP1"))
        {
            //rb.linearVelocity = new Vector2(0,0); slows upward movement
            _animator.SetBool("isBlocking", true);
        }
        else
        {
             _animator.SetBool("isBlocking", false);
        } 
        if (Input.GetButton("AttackP1_2"))
        {
             _animator.SetBool("isGrounded", false);
        }
    }      
}
