/*
Player movement and stuff 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb2d;
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        float xMove = Input.GetAxis("Horizontal");

        if (xMove != 0)
        {
            sr.flipX = xMove < 0;
        }

        Vector2 moveForce = new Vector2(xMove * speed * Time.deltaTime, 0);
        rb2d.AddForce(moveForce);
    }
}
