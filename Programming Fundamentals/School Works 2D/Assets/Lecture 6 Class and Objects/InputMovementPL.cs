using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovementPL : ProcessingLite.GP21
{

    //NOTE:
    // Shit don't work, fix later

    [Header("Variables")]
    public float circleDiameter = 2;
    public float maxSpeed;
    public float acceleration = 1.5f;
    public float deceleration = 1.5f;
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float opositeVelocity;
    private Vector2 velocityVector;

    [SerializeField]
    Vector2 lastInputDir;

    Vector2 circlePos;

    public float recoveryRate = 5;
    private float slowdownRate = 1;



    private void Start()
    {
        //Start in middle of screen
        circlePos = new Vector2(Width / 2, Height / 2);
    }

    private void Update()
    {

        Background(Color.black);

        Vector2 rawMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (rawMove.magnitude != 0)
        {
            lastInputDir = Vector2.MoveTowards(lastInputDir, move, recoveryRate * Time.deltaTime);
        }


        if (rawMove.magnitude == 0)
        {
            velocity -= acceleration * Time.deltaTime;
            lastInputDir = Vector2.MoveTowards(lastInputDir, Vector2.zero, recoveryRate * Time.deltaTime);
            velocityVector += move * -velocity * Time.deltaTime;

        }
        else if (rawMove.magnitude != 0)
        {
            velocity += acceleration * Time.deltaTime;
            velocityVector += move * velocity * Time.deltaTime;

        }


        if (velocity < 0)
            velocity = 0;

        if (velocity > maxSpeed)
            velocity = maxSpeed;


        velocityVector += move * velocity * Time.deltaTime;

        circlePos += velocityVector * Time.deltaTime;
        Circle(circlePos.x, circlePos.y, circleDiameter);
    }
}
