using UnityEngine;

public class PlayerBlockP1 : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.SetBool("isBlocking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("BlockP1"))
        {
            _animator.SetBool("isBlocking", true);
        }
        else
        {
             _animator.SetBool("isBlocking", false);
        } 
    }      
}
