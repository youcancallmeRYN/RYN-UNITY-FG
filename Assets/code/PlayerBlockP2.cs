using UnityEngine;

public class PlayerBlockP2 : MonoBehaviour
{
     [SerializeField] private Animator _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.SetBool("BlockP2", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("BlockP2"))
        {
            _animator.SetBool("isBlocking", true);
        }
        else
        {
             _animator.SetBool("isBlocking", false);
        }
    }
}
