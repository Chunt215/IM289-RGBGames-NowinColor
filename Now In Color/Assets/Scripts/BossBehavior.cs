using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb2d;

    private bool faceLeft = true;
    private bool faceRight = false;
    private int health = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (faceLeft == true && faceRight == false)
        {
            SlideLeft();
        }
        else if (faceRight == true && faceLeft == false)
        {
            SlideRight();
        }
    }

    void SlideLeft()
    {
        rb2d.velocity = -transform.right * speed * Time.deltaTime;
        rb2d.AddForce(-transform.right);
    }

    void SlideRight()
    {
        rb2d.velocity = transform.right * speed * Time.deltaTime;
        rb2d.AddForce(transform.right);
    }

    void Switch()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1
                                   , transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If player hits the turnRight object, switch facing/move directions 
        if (collision.gameObject.CompareTag("TurnRight"))
        {
            faceLeft = false;
            faceRight = true;
            Switch();
        }
        // If player hits the turnLeft object, switch facing/move directions 
        else if (collision.gameObject.CompareTag("TurnLeft"))
        {
            faceLeft = true;
            faceRight = false;
            Switch();
        }
    }
}
