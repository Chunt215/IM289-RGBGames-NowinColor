/*
Player movement and stuff 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Vector2 jumpForce = new Vector2(0, 5.0f);
    public bool canJump = true;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // yMove and xMove will be set to a value between -1 and 1
        float xMove = Input.GetAxis("Horizontal");

        // Getting our current position
        Vector3 newPos = transform.position;

        // Changing the position
        newPos.x += xMove * Time.deltaTime * speed;

        // Setting our position to the new one
        transform.position = newPos;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb2d.AddForce(jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }
}