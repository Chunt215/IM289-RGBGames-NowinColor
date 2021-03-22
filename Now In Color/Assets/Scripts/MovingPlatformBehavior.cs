using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour
{
    public float rightLimit;
    public float leftLimit;
    public float speed;
    public bool isVert;
    private int direction = 1;
    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        if (!isVert)
        {
            if (transform.position.x > rightLimit)
            {
                direction = -1;
            }
            else if (transform.position.x < leftLimit)
            {
                direction = 1;
            }

            movement = Vector3.right * direction * speed * Time.deltaTime;
            transform.Translate(movement);
        }
        else
        {
            if (transform.position.y > rightLimit)
            {
                direction = -1;
            }
            else if (transform.position.y < leftLimit)
            {
                direction = 1;
            }

            movement = Vector3.up * direction * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}
