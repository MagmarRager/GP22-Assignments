using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweekSizeAndRot : MonoBehaviour
{
    public GameObject laserPrefab;

    [Header("Position")]
    public float x;
    public float y;
    [Header("Size")]
    public float size = 0.5f;
    [Header("Rotation")]
    public float rotation; //Note: due to 2d, only in the z axis
    [Header("Misc")]
    public float moveSpeed;
    public float rotSpeed;
    public float sizeSpeed;







    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
        }


        // Movement x and y
        float xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float yMove = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 move = new Vector2(xMove, yMove).normalized;

        transform.position += move * Time.deltaTime * moveSpeed;



        // Resize with scroll
        float scrollSize = Input.GetAxis("Mouse ScrollWheel");

        transform.localScale += Vector3.one * size * scrollSize;



        // Rotate towoards mouse
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotDirection = Quaternion.AngleAxis(angle, Vector3.forward);


        transform.rotation = Quaternion.Lerp(transform.rotation, rotDirection, Time.deltaTime * rotSpeed);




        // rotate Robert version
        //Vector2 aim = Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition;
        //transform.up = aim;


    }



}
