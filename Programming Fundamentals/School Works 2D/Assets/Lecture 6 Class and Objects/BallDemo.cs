using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallDemo : ProcessingLite.GP21
{

    // WARNING: 18+ Contains a lot of balls
    [SerializeField]
    List<Ball> myBalls = new List<Ball>();

    BasePlayer myPlayer;

    [SerializeField]
    TMP_Text deathText; 

    private bool deadAsHell = false;
    public int ballsAmmount = 5;

    void Start()
    {
        deadAsHell = false;
        deathText.enabled = false;
        for (int i = 0; i < ballsAmmount; i++)
        {
            myBalls.Add(new Ball(Random.Range(0, Width), Random.Range(0, Height), Random.Range(0.3f, 0.8f), new Color32((byte)Random.Range(50, 255), (byte)Random.Range(50, 255), (byte)Random.Range(50, 255), 255)));
        }

        myPlayer = new BasePlayer(Width / 2, Height / 2, 0.5f, Color.green);
    }

    void addBalls()
    {
        myBalls.Add(new Ball(Random.Range(0, Width), Random.Range(0, Height), Random.Range(0.3f, 0.8f), new Color32((byte)Random.Range(50, 255), (byte)Random.Range(50, 255), (byte)Random.Range(50, 255), 255)));

        ballsAmmount++;
    }

    void Update()
    {
        Background(0);


        if (!deadAsHell)
        {
            myPlayer.UpdatePlayerPos();
            myPlayer.DrawPlayer();
        }

        for (int i = 0; i < ballsAmmount; i++)
        {
            if (CircleCollision(myPlayer.playerPos, myPlayer.circleDiameter / 2, myBalls[i].position, myBalls[i].ballDiameter / 2))
            {
                deathScreen();
            }
            else
            {
                myBalls[i].Draw();
                myBalls[i].UpdatePos();
            }
        }
    }

    void deathScreen()
    {
        for (int i = ballsAmmount; i > 0; i--)
        {
            myBalls.RemoveAt(i - 1);

        }
        ballsAmmount = 0;
        deadAsHell = true;
        myPlayer = null;
        deathText.enabled = true;
    }


    bool CircleCollision(Vector2 pos1, float size1, Vector2 pos2, float size2)
    {
        float maxDistance = size1 + size2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(pos1.x - pos2.x) > maxDistance || Mathf.Abs(pos1.x - pos2.x) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(pos1, pos2) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }

}
