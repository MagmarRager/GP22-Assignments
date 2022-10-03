using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float rotSpeed = 5;
    public float movSpeed = 5;

    private Rigidbody2D rigBody;

    private float xInput;
    private float yInput;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        rigBody.angularVelocity = -xInput * rotSpeed;
        rigBody.velocity = transform.right * movSpeed * yInput;
    }


}
