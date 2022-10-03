using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretController : MonoBehaviour
{
    public float rotSpeed;
    Quaternion rotDirection;

    private void Update()
    {

        Vector2 mousePosDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;


        float angle = Mathf.Atan2(mousePosDir.y, mousePosDir.x) * Mathf.Rad2Deg;
        rotDirection = Quaternion.AngleAxis(angle, Vector3.forward);

        
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotDirection, rotSpeed * Time.deltaTime);
    }


}
