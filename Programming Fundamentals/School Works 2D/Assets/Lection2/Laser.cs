using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 50;
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
