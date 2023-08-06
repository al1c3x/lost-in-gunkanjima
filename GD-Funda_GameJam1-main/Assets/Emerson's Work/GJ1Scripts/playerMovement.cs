using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    //Player properties:
    public float speed = 6.0f;
    public float jumpHeight = 4.0f;

    //character movement coordinates
    [HideInInspector] public float movementX = 0.0f;
    [HideInInspector] public float movementY = 0.0f;

    //Gravity value
    private const float gravity = -9.81f;
    private Vector3 velocity;

    //for Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRad = 0.4f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGround;

    //jump properties
    private float jumpTimer = 3.0f;
    private bool canJump = true;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the player is on the ground
        isGround = Physics.CheckSphere(groundCheck.position,
         groundCheckRad, groundLayer);

        //sets the velocity to a constant value when player is on the ground
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Sprint Mechanic
        if (Input.GetKey(KeyCode.LeftShift) && isGround)
        {
            speed = 3.0f;
        }
        else if(!Input.GetKey(KeyCode.LeftShift))
        {
            speed = 1.5f;
        }

        //horizontal and forward coordinates
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        //translates the player
        Vector3 move = transform.right * movementX + transform.forward * movementY;
        controller.Move(move * speed * Time.deltaTime);

        //Jumping Mechanic
        if (Input.GetButtonDown("Jump") && isGround && canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            canJump = !canJump;
        }
        else if(!canJump)
        {
            jumpTimer -= Time.deltaTime;
            if(jumpTimer <= 0.0f)
            {
                jumpTimer = 3.0f;
                canJump = !canJump;
            }
        }

        //apply gravity to the player
        velocity.y += 2.0f * gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded == true && (Math.Abs(movementX) > 0f || Math.Abs(movementY) > 0f) && SFXManager.SFXInstance.isPlayMove() == false)
        {
            SFXManager.SFXInstance.playMove();
        }
        else
        {
            SFXManager.SFXInstance.stopSFX(SFXManager.SFXInstance.Move);
        }
    }

}
