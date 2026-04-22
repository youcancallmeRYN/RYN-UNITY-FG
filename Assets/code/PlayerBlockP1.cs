using UnityEngine;

public class PlayerBlockP1 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator.SetBool("isBlocking", false);
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
    }      
}
