/*
Player movement and stuff 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5.0f;
    public float jumpForce = 100;
    public LayerMask mask;

    private SpriteRenderer sr;
    private bool canJump = true;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jumping();

        if(transform.position.y < -9)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void Movement()
    {
        // yMove and xMove will be set to a value between -1 and 1
        float xMove = Input.GetAxis("Horizontal");

        if (xMove != 0)
        {
            sr.flipX = xMove < 0;
        }

        // Getting our current position
        Vector3 newPos = transform.position;

        // Changing the position
        newPos.x += xMove * Time.deltaTime * speed;

        // Setting our position to the new one
        transform.position = newPos;

        anim.SetFloat("xMove", xMove);
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            canJump = false;
        }

        // Check to see what layer has hit and collect that information
        RaycastHit2D hit = Physics2D.Linecast(rb2d.position, rb2d.position + Vector2.down, mask);

        // If the player has hit the ground, set jumping to false
        if (hit.transform != null)
        {
            anim.SetBool("jumping", false);
        }
        else
        {
            anim.SetBool("jumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            canJump = true;
            collision.gameObject.GetComponent<SpriteRenderer>().color = sr.color;
        }

        if(collision.gameObject.tag == "Wall")
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().color == sr.color)
            {
                Destroy(collision.gameObject.GetComponent<BoxCollider2D>());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        switch(collider.tag)
        {
            case "Blue":
                sr.color = Color.blue;
                break;
            case "Red":
                sr.color = Color.red;
                break;
            case "Green":
                sr.color = Color.green;
                break;
            case "Yellow":
                sr.color = Color.yellow;
                break;
            default:
                sr.color = Color.white;
                break;
        }
    }
}