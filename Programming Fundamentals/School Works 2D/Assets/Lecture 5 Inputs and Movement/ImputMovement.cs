using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ImputMovement : MonoBehaviour
{

    // NOTE:
    //      THE SCRIPT IS USED IN "Lecture 2" sampleScene!!!
    //      ALSO THIS SCRIPT IS OUTDATED UPDATED VERSION IS IN 

    [Header("Variables")]
    public float maxSpeed;
    public float acceleration = 1.5f;
    public float deceleration = 1.5f;
    [SerializeField]
    private float velocity;

    [SerializeField]
    Vector3 lastInputDir;


    private void Update()
    {
  

        Vector2 rawMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (rawMove.magnitude != 0)
        {
            lastInputDir = move;
        }




        if (rawMove.magnitude == 0)
        {
            velocity -= deceleration * Time.deltaTime;
        }
        else if (rawMove.magnitude != 0)
        {
            velocity += acceleration * Time.deltaTime;
        }

        if (velocity < 0)
            velocity = 0;

        if (velocity > maxSpeed)
            velocity = maxSpeed;

        transform.position += lastInputDir * velocity * Time.deltaTime;



        Debug.Log(move.magnitude);
    }


}
