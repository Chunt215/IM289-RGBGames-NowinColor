/*
Player movement and stuff 
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5.0f;
    public float jumpForce = 100;

    static public int lives = 3;
    public LayerMask mask;
    public Text livesText;
    public int damage = 1;
    public Vector2 checkpointPos;

    public int coins = 0;
    public Text coinText;

    public bool canKill = false;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int bulletSpeed = 25;
    public int bulletLife = 3;

    public SpriteRenderer sr;
    private string sceneName;

    private bool canJump = true;
    public bool canShoot = true;

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
        Shrinking();

        if(transform.position.y < -9)
        {
            LifeLost();
        }

        if (lives == 0)
        {
            lives = 3;
            Destroy(livesText);
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canKill == true)
        {
            Shooting();
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

    void Shrinking()
    {
        if (Input.GetKey(KeyCode.C))
        {
            anim.SetBool("canShrink", true);
        }
        else
        {
            anim.SetBool("canShrink", false);
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

        // If the player collides with the turning objects
        // Have the layer the player is on ignore the layer the turns are on
        if(collision.gameObject.CompareTag("TurnRight") || 
           collision.gameObject.CompareTag("TurnLeft"))
        {
            Physics2D.IgnoreLayerCollision(3, 8);
        }

        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Hazard"))
        {
            LifeLost();
        }

        if(collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinText.text = coins.ToString();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Color Enemy"))
        {
            sr.color = Color.white;
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
                    canKill = false;
                    speed = 5.0f;
                    jumpForce = 300;
                    break;
                case "Red":
                    sr.color = Color.red;
                    canKill = false;
                    speed = 5.0f;
                    jumpForce = 300;
                    break;
                case "Yellow":
                     sr.color = Color.yellow;
                    canKill = false;
                    speed = 5.0f;
                    jumpForce = 300;
                    break;
                    //default:
                    // sr.color = Color.white;
                    //break;
            }

            if (collider.CompareTag("Checkpoint"))
            {
                checkpointPos = collider.transform.position;
            }
        }
        else if (CheckMixable())
        {
            if (collider.tag == "Blue" && sr.color == Color.red)
            {
                sr.color = purple;
                jumpForce = 600;
                speed = 5.0f;
                canKill = false;
            }

            if (collider.tag == "Red" && sr.color == Color.blue)
            {
                sr.color = purple;
                jumpForce = 600;
                speed = 5.0f;
                canKill = false;
            }

            if (collider.tag == "Yellow" && sr.color == Color.red)
            {
                sr.color = orange;
                speed = 10.0f;
                jumpForce = 300;
                canKill = false;
            }

            if (collider.tag == "Red" && sr.color == Color.yellow)
            {
                sr.color = orange;
                speed = 10.0f;
                jumpForce = 300;
                canKill = false;
            }

            if (collider.tag == "Yellow" && sr.color == Color.blue)
            {
                sr.color = Color.green;
                canKill = true;
                speed = 5.0f;
                jumpForce = 300;
            }

            if (collider.tag == "Blue" && sr.color == Color.yellow)
            {
                sr.color = Color.green;
                canKill = true;
                speed = 5.0f;
                jumpForce = 300;
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

    void ChangeHealth()
    {
        livesText.text = lives.ToString();
    }

    void LifeLost()
    {
        lives -= damage;
        ChangeHealth();
        transform.position = checkpointPos;
    }

    void Shooting()
    {
        if (sr.color == Color.green)
        {

            if (sr.flipX == false)
            {
                GameObject bullet = Instantiate(bulletPrefab,
                                firePoint.position, firePoint.rotation);

                Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();

                rb2d.AddRelativeForce(firePoint.right * bulletSpeed);

                Destroy(bullet, bulletLife);
            }
            else
            {
                GameObject bullet = Instantiate(bulletPrefab,
                                new Vector3(firePoint.transform.position.x - 1.62f, firePoint.transform.position.y), firePoint.rotation);

                Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();

                rb2d.AddRelativeForce(-firePoint.right * bulletSpeed);

                Destroy(bullet, bulletLife);
            }

        }
    }
}