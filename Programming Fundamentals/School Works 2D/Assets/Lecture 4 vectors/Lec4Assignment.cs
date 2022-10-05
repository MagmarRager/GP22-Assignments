using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lec4Assignment : ProcessingLite.GP21
{
    public float velocityMagnitude;

    public float circleRadius;
    public float speedMultiplyer = 1;
    public float maxDragSpeed = 10;

    public Vector2 CirclePosition;
    private Vector2 velocity;
    private Vector2 circleCameraPos;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Background(0);

        Circle(CirclePosition.x, CirclePosition.y, circleRadius*2);

        circleCameraPos = Camera.main.WorldToViewportPoint(CirclePosition);


        if (Input.GetMouseButtonDown(0))
        {
            velocity = Vector2.zero;
            CirclePosition = mousePos;
        }
        if(Input.GetMouseButton(0))
        {
            Line(CirclePosition.x, CirclePosition.y, mousePos.x, mousePos.y);
            //Simply for insperctor veiwing
            velocityMagnitude = Vector2.ClampMagnitude(mousePos - CirclePosition, maxDragSpeed).magnitude;
        }
        if(Input.GetMouseButtonUp(0))
        {
            velocity = mousePos - CirclePosition;
        }

        // Checking velocity is a BUGFIX, if not there, theres chance for ball getting stuck outside due to multiplying * -1 every frame! 
        if ((circleCameraPos.x > 1 && velocity.x > 0) || (circleCameraPos.x < 0 && velocity.x < 0))
        {
            velocity.x *= -1;
        }
        if ((circleCameraPos.y > 1 && velocity.y > 0 )|| (circleCameraPos.y < 0 && velocity.y < 0))
        {
            velocity.y *= -1;
        }

        CirclePosition += Vector2.ClampMagnitude(velocity, maxDragSpeed) * Time.deltaTime * speedMultiplyer;
    }
}
