/*
Enemy movement and death stuff 
*/
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb2d;
    public LayerMask groundCheck;

    private bool facingRight = true;

    RaycastHit2D hit;

    void Update()
    {
        // Shoot a raycast downwards from the position of the enemy to
        // check for the ground
        hit = Physics2D.Raycast(rb2d.position, rb2d.position + Vector2.down
              , groundCheck);
    }

    void FixedUpdate()
    {
        if(hit.collider != false)
        {
            if (facingRight)
            {
                rb2d.velocity = new Vector2(speed * Time.deltaTime, 
                                rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(-speed * Time.deltaTime,
                                rb2d.velocity.y);
            }
        }
        else
        {
            facingRight = !facingRight;
            transform.localScale = new Vector2(-transform.localScale.x, 1f);
        }
    }
}
