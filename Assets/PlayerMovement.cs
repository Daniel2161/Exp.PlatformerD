using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Rigidbody2D rb;
    public float runSpeed = 40f;
    //public float jumpSpeed = 20f;

    /* This was an attempt to use our knowledge to create a jump button - we instead 
         created a teleport that moves the player horizontally at a set distance / speed.*/
    // public float jumpSpeed = 20f;

    public float horizontalMove = 0f;
    public float jump;

    public bool isJumping;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);

        //jump = false;


        /* This was an attempt to use our knowledge to create a jump button - we instead 
       created a teleport that moves the player horizontally at a set distance / speed.*/
        // controller.Move(verticalMove * jumpSpeed, false, true);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

}
