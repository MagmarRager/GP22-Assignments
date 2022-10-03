using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{

    public Vector2 position;
    private Vector2 velocity;
    public float ballDiameter;

    private Color32 colorOfBall;

    public Ball(float x, float y)
    {
        colorOfBall = Color.white;

        ballDiameter = 0.5f;

        position = new Vector2(x, y);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }
    public Ball(float x, float y, Color32 ballColor)
    {
        colorOfBall = ballColor;

        ballDiameter = 0.5f;

        position = new Vector2(x, y);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }
    public Ball(float x, float y, float diameter)
    {
        colorOfBall = Color.white;

        ballDiameter = diameter;

        position = new Vector2(x, y);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    public Ball(float x, float y, float diameter, Color32 ballLineColor)
    {
        colorOfBall = ballLineColor;

        ballDiameter = diameter;

        position = new Vector2(x, y);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 15) - 5;
        velocity.y = Random.Range(0, 15) - 5;
        
    }



    public void Draw()
    {
        Stroke(colorOfBall.r, colorOfBall.b, colorOfBall.g);
        Fill(255, 0, 0);
        Circle(position.x, position.y, ballDiameter);
    }

    public void UpdatePos()
    {
        if((position.x + ballDiameter > Width && velocity.x > 0) || (position.x - ballDiameter < 0 && velocity.x < 0))
        {
            velocity.x *= -1;
        }

        if ((position.y + ballDiameter > Height && velocity.y > 0) || (position.y - ballDiameter < 0 && velocity.y < 0))
        {
            velocity.y *= -1;
        }

        position += velocity * Time.deltaTime;
    }

}
