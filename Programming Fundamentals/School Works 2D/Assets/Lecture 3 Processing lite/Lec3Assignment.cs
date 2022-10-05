using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Lec3Assignment : ProcessingLite.GP21
{
    public Transform APos;
    private float xA;
    private float yA;
    public Transform TPos;
    private float xT;
    private float yT;

    public float strokeWeight = 1;
    public int Strokes = 1;

    [SerializeField]
    private int randomColorNum = 0;
    [SerializeField]
    bool ascend;

    public Color32[] RandomizedColors;
    public Color32 thirdLineColor;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    public Vector2 Boo;


    void Update()
    {
        Background(0);

        Stroke(255);
        StrokeWeight(strokeWeight);

        DrawParable();

        DrawInitials();
    }

    void DrawInitials()
    {



        //Draws a "A"
        BeginShape();
        Vertex(-1f + xA, 0 + yA);
        Vertex(-1.5f + xA, 0 + yA);
        Vertex(-1.5f + xA, 3 + yA);
        Vertex(0.5f + xA, 3 + yA);
        Vertex(0.5f + xA, 0 + yA);
        Vertex(0f + xA, 0 + yA);
        Vertex(0f + xA, 2.3f + yA);
        Vertex(-1f + xA, 2.3f + yA);
        EndShape(true);

        //Draws a "T"
        BeginShape();
        Vertex(-1f + xT, 1.4f + yT);
        Vertex(2.5f + xT, 1.4f + yT);
        Vertex(2.5f + xT, 0.9f + yT);
        Vertex(1.8f + xT, 0.9f + yT);
        Vertex(1.8f + xT, 0f + yT);
        Vertex(1.3f + xT, 0f + yT);
        Vertex(1.3f + xT, 0.9f + yT);
        Vertex(-1f + xT, 0.9f + yT);
        EndShape(true);


        //Specific positions to draw boxes to make a fusing effect when the text is over one another
        xA = APos.position.x;
        yA = APos.position.y;

        xT = TPos.position.x;
        yT = TPos.position.y;

        float boxSize = 0.25f;
        Square(0.9f + xA, boxSize / 2 + strokeWeight / 10 / 2 + yA, boxSize);

        NoStroke();
        float strokeOffset = strokeWeight / 10 / 2;
        //Right Blocker
        Rect(0 + xA + strokeOffset, 3 + yA - strokeOffset, 0.5f + xA - strokeOffset, 0 + yA + strokeOffset);
        //Left Blocker
        Rect(-1.5f + xA + strokeOffset, 3 + yA - strokeOffset, -1f + xA - strokeOffset, 0 + yA + strokeOffset);


        // T Mid Blocker
        Rect(-1f + strokeWeight / 10 + xT, 1.4f + yT - strokeOffset, 2.5f + xT - strokeOffset, 0.9f + yT + strokeOffset);

    }

    void DrawParable()
    {
        //Parable down below
        for (int i = 0; i < Strokes + 1; i++)
        {
            if (i < 0)
                i = 0;
            // goes pos1 -> pos2
            //               |
            //               V
            //              pos3

            //Take the first two positions find the diffrence then devide by the ammount of strokes wanted
            Vector3 diff1 = (pos2.position - pos1.position) / Strokes;

            Vector3 diff2 = (pos3.position - pos2.position) / Strokes;

            Vector2 startPos = pos1.position + diff1 * i;

            Vector2 endPos = pos2.position + diff2 * i;

            //For color effects on the parabol
            if (i % 3 == 0)
            {
                Stroke(thirdLineColor.r, thirdLineColor.g, thirdLineColor.b);

            }
            else
            {

                if (randomColorNum == 0)
                {
                    ascend = true;
                }
                else if (randomColorNum >= RandomizedColors.Length - 1)
                {
                    ascend = false;
                }
                if (ascend)
                    randomColorNum++;
                else if (!ascend)
                    randomColorNum--;
                //int randomColorNum = Random.Range(0, RandomizedColors.Length);
                Stroke(RandomizedColors[randomColorNum].r, RandomizedColors[randomColorNum].g, RandomizedColors[randomColorNum].b);
            }


            Line(startPos.x, startPos.y, endPos.x, endPos.y);
        }
    }


}
