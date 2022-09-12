using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [Header("Variables")]
    public float moveSpeed;
    public float rotSpeed;


    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Instantiate(laserPrefab, transform.position, transform.rotation);
        //}


        // Movement x and y
        float xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float yMove = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 move = new Vector2(xMove, yMove).normalized;

        transform.position += move * Time.deltaTime * moveSpeed;




        // Rotate towoards mouse
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotDirection = Quaternion.AngleAxis(angle, Vector3.forward);


        transform.rotation = Quaternion.Lerp(transform.rotation, rotDirection, Time.deltaTime * rotSpeed);
    }


}
