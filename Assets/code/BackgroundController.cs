using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos;
    public GameObject camera; 
    public float parallaxEFX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = camera.transform.position.x * parallaxEFX; //0=move, 1=won't, 0.5=move at halfspeed
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
