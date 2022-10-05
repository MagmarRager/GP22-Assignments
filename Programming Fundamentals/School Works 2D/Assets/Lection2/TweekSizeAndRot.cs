using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweekSizeAndRot : MonoBehaviour
{

    // Outplayed in SampleScene

    [Header("Start Size")]
    public float size = 0.5f;
    [Header("Misc")]
    public float moveSpeed;
    public float rotSpeed;
    public float sizeSpeed;

    [Header("Component")]
    public GameObject laserPrefab;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(laserPrefab, transform.position, transform.rotation);
        }

        Movement();

        Resize();

        RotateToMouse();
    }

    void Movement()
    {
        float xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float yMove = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 move = new Vector2(xMove, yMove).normalized;

        transform.position += move * Time.deltaTime * moveSpeed;
    }


    void Resize()
    {
        float scrollSize = Input.GetAxis("Mouse ScrollWheel");

        transform.localScale += Vector3.one * size * scrollSize;
    }


    void RotateToMouse()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotDirection = Quaternion.AngleAxis(angle, Vector3.forward);


        transform.rotation = Quaternion.Lerp(transform.rotation, rotDirection, Time.deltaTime * rotSpeed);
    }

}
