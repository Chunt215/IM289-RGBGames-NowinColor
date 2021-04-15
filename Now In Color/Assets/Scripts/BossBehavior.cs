using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb2d;
    public Sprite[] bossVariants;

    private bool faceLeft = true;
    private bool faceRight = false;
    private int health = 9;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
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

        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            switch (health)
            {
                case 8:
                    sr.sprite = bossVariants[1];
                    break;
                case 7:
                    sr.sprite = bossVariants[2];
                    break;
                case 6:
                    sr.sprite = bossVariants[3];
                    break;
                case 5:
                    sr.sprite = bossVariants[4];
                    break;
                case 4:
                    sr.sprite = bossVariants[5];
                    break;
                case 3:
                    sr.sprite = bossVariants[6];
                    break;
                case 2:
                    sr.sprite = bossVariants[7];
                    break;
                case 1:
                    sr.sprite = bossVariants[8];
                    break;
                case 0:
                    Destroy(this.gameObject);
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
