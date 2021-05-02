/*****************************************************************************
// File Name:                  
// Primary Author :            Adam Jensen
*****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb2d;

    private bool isLeft = true;
    private bool isRight = false;
    private Color purple;
    private Color orange;
    private List<Color> primaries = new List<Color>();
    private List<Color> secondaries = new List<Color>();
    private SpriteRenderer sr;

    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        purple = new Color(0.5f, 0, 1);
        orange = new Color(1, 0.5f, 0);
        primaries.Add(Color.red);
        primaries.Add(Color.blue);
        primaries.Add(Color.yellow);
        secondaries.Add(orange);
        secondaries.Add(purple);
        secondaries.Add(Color.green);
    }

    void FixedUpdate()
    {
        if (isLeft == true && isRight == false)
        {
            MoveLeft();
        }
        else if (isRight == true && isLeft == false)
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        rb2d.velocity = -transform.right * speed * Time.deltaTime;
        rb2d.AddForce(-transform.right);
    }

    void MoveRight()
    {
        rb2d.velocity = transform.right * speed * Time.deltaTime;
        rb2d.AddForce(transform.right);
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1
                                   , transform.localScale.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If player hits the turnRight object, switch facing/move directions 
        if (collision.gameObject.CompareTag("TurnRight"))
        {
            isLeft = false;
            isRight = true;
            Flip();
        }
        // If player hits the turnLeft object, switch facing/move directions 
        else if (collision.gameObject.CompareTag("TurnLeft"))
        {
            isLeft = true;
            isRight = false;
            Flip();
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private bool Mixable()
    {
        bool canMix = false;

        for (int i = 0; i < primaries.Count; i++)
        {
            if (sr.color == primaries[i])
            {
                canMix = true;
                return canMix;
            }
            else
            {
                canMix = false;
            }
        }

        return canMix;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sr.color == Color.white || !Mixable())
        {
            switch (collision.tag)
            {
                case "Blue":
                    sr.color = Color.blue;
                    break;
                case "Red":
                    sr.color = Color.red;
                    break;
                case "Yellow":
                    sr.color = Color.yellow;
                    break;
            }
        }
        else if(Mixable())
        {
            if (collision.tag == "Blue" && sr.color == Color.red)
            {
                sr.color = purple;
            }

            if (collision.tag == "Red" && sr.color == Color.blue)
            {
                sr.color = purple;
            }

            if (collision.tag == "Yellow" && sr.color == Color.red)
            {
                sr.color = orange;
            }

            if (collision.tag == "Red" && sr.color == Color.yellow)
            {
                sr.color = orange;
            }

            if (collision.tag == "Yellow" && sr.color == Color.blue)
            {
                sr.color = Color.green;
            }

            if (collision.tag == "Blue" && sr.color == Color.yellow)
            {
                sr.color = Color.green;
            }
        }
    }
}
