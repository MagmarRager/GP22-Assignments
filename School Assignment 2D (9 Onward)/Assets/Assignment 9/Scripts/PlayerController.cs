using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotSpeed = 10;

    private Vector2 movement;
    private Vector2 rotTarget;
    private Rigidbody2D rigBody;

    private void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(xInput, yInput);

        RotateTransform();
    }



    void RotateTransform()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            rotTarget = mousePosDir;
        }
        else if (movement.magnitude != 0)
        {
            rotTarget = rigBody.velocity;
        }

        float angle = Mathf.Atan2(rotTarget.y, rotTarget.x) * Mathf.Rad2Deg;
        Quaternion rotDirection = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotDirection, Time.deltaTime * rotSpeed);
    }
    private void FixedUpdate()
    {
        MoveForce();
    }

    void MoveForce()
    {
        rigBody.velocity = movement * moveSpeed;
    }


}
