/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:         Adam Jensen
//
// Who Completed What 
//(if more than one author): Adam created the lives mechanic, all sounds, 
//                           all collisions expect for platform, wall, and
//                           boss barrier, all parts of the lives, and 
//                           some of the shooting, moving, jumping, and 
//                           crouching (mainly animation).
*****************************************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5.0f;
    public float jumpForce = 100;

    public Collider2D standingCollider;
    public Collider2D crouchingCollider;

    public AudioClip jumpSound;
    public AudioClip dieSound;
    public AudioClip shootSound;
    public AudioClip checkpointSound;
    public AudioClip coinSound;

    public int lives = 3;
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
    private bool canCrouch = false;

    private Animator anim;

    private Color purple;
    private Color orange;

    private List<Color> primaries = new List<Color>();
    private List<Color> secondaries = new List<Color>();

    void Awake()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        standingCollider = this.gameObject.GetComponent<PolygonCollider2D>();
        crouchingCollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        coinText = GameObject.Find("CoinText").GetComponent<Text>();

        crouchingCollider.enabled = false;
        anim = GetComponent<Animator>();
        purple = new Color(0.5f, 0, 1);
        orange = new Color(1, 0.5f, 0);
        primaries.Add(Color.red);
        primaries.Add(Color.blue);
        primaries.Add(Color.yellow);
        secondaries.Add(orange);
        secondaries.Add(purple);
        secondaries.Add(Color.green);

        lives = 3;
        livesText.text = lives.ToString();
        coins = 0;
        coinText.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jumping();
        Crouching();

/*        if(transform.position.y < -9)
        {
            LifeLost();
        }*/

        if (lives <= 0)
        {
            lives = 3;
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

            Vector3 camPos = Camera.main.transform.position;

            AudioSource.PlayClipAtPoint(jumpSound, camPos, 0.25f);
        }

        // Check to see what layer has hit and collect that information
        RaycastHit2D hit = Physics2D.Linecast(rb2d.position, rb2d.position + Vector2.down, mask);

        // If the player has hit the ground, set jumping to false
        //if (hit.transform != null)
        //{
        //    anim.SetBool("jumping", false);
        //}
        //else
        //{
        //    anim.SetBool("jumping", true);
        //}
        anim.SetBool("jumping", !canJump);
    }

    void Crouching()
    {
        if (Input.GetKey(KeyCode.C))
        {
            canCrouch = true;
            anim.SetBool("canCrouch", true);
        }
        else
        {
            anim.SetBool("canCrouch", false);
            canCrouch = false;
        }

        if(canCrouch == true)
        {
            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
        else
        {
            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
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

            Vector3 camPos = Camera.main.transform.position;

            AudioSource.PlayClipAtPoint(coinSound, camPos, 0.25f);
        }

        if (collision.gameObject.CompareTag("Life"))
        {
            lives++;
            livesText.text = lives.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Color Enemy"))
        {
            sr.color = Color.white;
        }

        if (collision.gameObject.CompareTag("FellOff"))
        {
            LifeLost();
        }

        if(collision.gameObject.CompareTag("BossBarrier"))
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

                Vector3 camPos = Camera.main.transform.position;

                AudioSource.PlayClipAtPoint(checkpointSound, camPos, 0.5f);
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
        sr.color = Color.white;

        Vector3 camPos = Camera.main.transform.position;

        AudioSource.PlayClipAtPoint(dieSound, camPos);
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

            Vector3 camPos = Camera.main.transform.position;

            AudioSource.PlayClipAtPoint(shootSound, camPos, 0.25f);
        }
    }
}