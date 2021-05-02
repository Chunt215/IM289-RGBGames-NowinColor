/*****************************************************************************
// File Name:                  
// Primary Author :            
// Additional Authors:      Adam Jensen
//
// Who Completed What 
//(if more than one author): Adam wrote the code for enemy movement and
//                           for enemy changing sprites when hit. 
*****************************************************************************/

using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb2d;
    public Sprite[] bossVariants;
    public GameObject orangeBarrier;
    public GameObject blackBarrier;
    public GameObject player;
    public GameObject redBeam;
    public GameObject blueBeam;
    public GameObject yellowBeam;
    public Vector3 barrierPos;

    private bool faceLeft = true;
    private bool faceRight = false;
    public int health = 9;
    private SpriteRenderer sr;
    private Color orange;
    private Color purple;
    private float awayForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player(Clone)");
        orange = new Color(1f, 0.5f, 0, 1f);
        purple = new Color(0.5f, 0, 1f, 1f);
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

        //barrierPos = transform.position;

        //if (faceRight)
        //{
        //    barrierPos.x += 9;
        //}
        //else
        //{
        //    barrierPos.x -= 9;
        //}

        //if (health == 6 && GameObject.Find("OrangeBarrier(Clone)") == null)
        //{
        //    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -awayForce);
        //    Invoke("SpawnBarrier", 0.5f);
        //}

        //if (health == 3 && GameObject.Find("BlackBarrier(Clone)") == null)
        //{
        //    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * -awayForce);
        //    Destroy(GameObject.Find("OrangeBarrier(Clone)"));
        //    Invoke("SpawnBarrier", 0.5f);
        //}
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

        //if(collision.gameObject.CompareTag("Player"))
        //{
        //    if(collision.gameObject.GetComponent<SpriteRenderer>().color == orange && health > 3)
        //    {
        //        health--;
        //        switch(health)
        //        {
        //            case 6:
        //                sr.sprite = bossVariants[3];
        //                break;
        //            case 5:
        //                sr.sprite = bossVariants[4];
        //                break;
        //            case 4:
        //                sr.sprite = bossVariants[5];
        //                break;
        //        }
        //    }

        //    if (collision.gameObject.GetComponent<SpriteRenderer>().color == purple)
        //    {
        //        health--;
        //        switch(health)
        //        {
        //            case 3:
        //                sr.sprite = bossVariants[6];
        //                break;
        //            case 2:
        //                sr.sprite = bossVariants[7];
        //                break;
        //            case 1:
        //                sr.sprite = bossVariants[8];
        //                break;
        //            case 0:
        //                Destroy(this.gameObject);
        //                Destroy(GameObject.Find("BlackBarrier(Clone)"));
        //                break;
        //        }
        //    }
        //}

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

    void SpawnBarrier()
    {
        if(health == 6)
        {
            Instantiate(orangeBarrier, barrierPos, Quaternion.identity);
            blueBeam.SetActive(false);
            redBeam.SetActive(true);
        }
        else if(health == 3)
        {
            Instantiate(blackBarrier, barrierPos, Quaternion.identity);
            yellowBeam.SetActive(false);
            blueBeam.SetActive(true);
        }
    }
}
