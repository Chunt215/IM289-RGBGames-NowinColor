/*
Enemy movement and death stuff 
*/
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb2d;

    private SpriteRenderer sr;
    private bool isLeft = true;
    private bool isRight = false;

    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
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
    }

}
