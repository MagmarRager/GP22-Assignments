using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.PlayerSettings.SplashScreen;

public class BasePlayer : ProcessingLite.GP21
{

    [Header("Variables")]
    public float circleDiameter;
    private Color32 playerColor;

    private float accSpeed = 40;
    private float deccMultiplyer = 5;
    private float maxSpeed = 10;

    public Vector2 move, playerPos, acceleration;

    public BasePlayer(float xPos, float yPos, float diameter, Color32 lineColor )
    {
        playerPos = new Vector2(xPos,yPos);
        circleDiameter = diameter;
        playerColor = lineColor;
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


