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
        Debug.Log("Player does things");
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

    void jumping()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {   
            rb2d.AddForce(Vector2.up * jumpForce);
            isJump = true;
        }

    }
}
