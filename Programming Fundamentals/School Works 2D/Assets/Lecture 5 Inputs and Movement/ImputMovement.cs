using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ImputMovement : MonoBehaviour
{

    // NOTE:
    //      THE SCRIPT IS USED IN "Lecture 2" sampleScene!!!

    [Header("Variables")]
    public float maxSpeed;
    public float acceleration = 1.5f;
    public float deceleration = 1.5f;
    [SerializeField]
    private float currentSpeed;

    Vector3 lastInputDir;

    private void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector2(xMove, yMove).normalized;

        if (move.magnitude != 0)
        {
            lastInputDir = move;
        }

        if (currentSpeed < 0)
            currentSpeed = 0;


        if (move.magnitude == 0 && currentSpeed > 0)
        {

            currentSpeed -= deceleration * Time.deltaTime;
        }
        else if (move.magnitude != 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;

        transform.position += lastInputDir * currentSpeed * Time.deltaTime;

        Debug.Log(move.magnitude);
    }


}
