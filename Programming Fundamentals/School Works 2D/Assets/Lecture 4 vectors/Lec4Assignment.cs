using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lec4Assignment : ProcessingLite.GP21
{

    public float circleRadius;
    public float speed = 1;

    public Vector2 CirclePosition;
    private Vector2 direction;

    [SerializeField]
    private Vector2 circleCameraPos;


    private float circleRadiusInCamera;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Background(0);

        Circle(CirclePosition.x, CirclePosition.y, circleRadius*2);

        circleCameraPos = Camera.main.WorldToViewportPoint(CirclePosition);


        if (Input.GetMouseButtonDown(0))
        {
            //CirclePosition = mousePos;

            Line(CirclePosition.x, CirclePosition.y, mousePos.x, mousePos.y);

            direction = mousePos - CirclePosition;

        }


        if ((circleCameraPos.x > 1 && direction.x > 0) || (circleCameraPos.x < 0 && direction.x < 0))
        {
            direction.x *= -1;
        }
        if ((circleCameraPos.y > 1 && direction.y > 0 )|| (circleCameraPos.y < 0 && direction.y < 0))
        {
            direction.y *= -1;
        }


        CirclePosition += direction * Time.deltaTime * speed;






    }
}
