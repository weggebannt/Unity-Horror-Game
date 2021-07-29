using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController controller;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 2f;
    Animator animator;

    bool wPressed;
    bool aPressed;
    bool sPressed;
    bool dPressed;
    bool shiftPressed;
    bool isJumping;
    bool isSneaking;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown("KeyCode.w"))
        {
            wPressed = true;
        }
        if (Input.GetKeyDown("KeyCode.a"))
        {
            aPressed = true;
        }
        if (Input.GetKeyDown("KeyCode.d"))
        {
            dPressed = true;
        }
        if (Input.GetKeyDown("KeyCode.s"))
        {
            sPressed = true;
        }

        if (wPressed && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        if (dPressed && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        if (aPressed && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
        if (sPressed && isGrounded)
        {
            animator.SetBool("isWalking", true);
        }
    }
}