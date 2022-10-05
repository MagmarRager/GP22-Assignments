using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovementPL : ProcessingLite.GP21
{
    //
    //NOTE: Located in lecture 6 ProLiteClassScene!
    //

    [Header("Customization")]
    public float circleDiameter;
    public Color32 playerColor;

    [Header("Speed Changes")]
    public float accSpeed = 40;
    public float deccMultiplyer = 5;
    public float maxSpeed = 10;

    private Vector2 move, playerPos, acceleration;

    private void Start()
    {
        playerPos = new Vector2(Width/2, Height/2);
    }
    private void Update()
    {
        UpdatePlayerPos();
        DrawPlayer();
    }

    public void UpdatePlayerPos()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;


        if (move.sqrMagnitude == 0)
        {
            acceleration *= 1 - Time.deltaTime * deccMultiplyer;
        }
        else
            acceleration += move * Time.deltaTime * accSpeed;

        acceleration = Vector2.ClampMagnitude(acceleration, maxSpeed);

        playerPos += acceleration * Time.deltaTime;
    }

    public void DrawPlayer()
    {
        Fill(0, 0, 255);
        Stroke(playerColor.r, playerColor.g, playerColor.b);
        Circle(playerPos.x, playerPos.y, circleDiameter);
    }
}
