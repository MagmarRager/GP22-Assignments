using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{

    public GameObject bullet;

    public float projectileSpeed = 10;

    public Transform shootingPos;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, shootingPos.position, transform.rotation);

            newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;

        }
    }


}
