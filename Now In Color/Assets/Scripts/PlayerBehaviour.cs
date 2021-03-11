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
    private Color purple;
    private Color orange;
    private List<Color> primaries = new List<Color>();
    private List<Color> secondaries = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
        purple = new Color(0.5f, 0, 1);
        orange = new Color(1, 0.5f, 0);
        primaries.Add(Color.red);
        primaries.Add(Color.blue);
        primaries.Add(Color.yellow);
        secondaries.Add(orange);
        secondaries.Add(purple);
        secondaries.Add(Color.green);
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
                collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (sr.color == Color.white || !CheckMixable())
        {
            switch (collider.tag)
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
                    //default:
                    // sr.color = Color.white;
                    //break;
            }
        }
        else if (CheckMixable())
        {
            if (collider.tag == "Blue" && sr.color == Color.red)
            {
                sr.color = purple;
            }

            if (collider.tag == "Red" && sr.color == Color.blue)
            {
                sr.color = purple;
            }

            if (collider.tag == "Yellow" && sr.color == Color.red)
            {
                sr.color = orange;
            }

            if (collider.tag == "Red" && sr.color == Color.yellow)
            {
                sr.color = orange;
            }

            if (collider.tag == "Yellow" && sr.color == Color.blue)
            {
                sr.color = Color.green;
            }

            if (collider.tag == "Blue" && sr.color == Color.yellow)
            {
                sr.color = Color.green;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            collider.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    bool CheckMixable()
    {
        bool canMix = false;

        for(int i = 0; i < primaries.Count; i++)
        {
            if(sr.color == primaries[i])
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
}