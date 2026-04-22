using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class removePartical : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RemovePartical());
    }

    private IEnumerator RemovePartical()
    {
       yield return new WaitForSeconds(0.5f);
       Destroy(gameObject);
    }
}
