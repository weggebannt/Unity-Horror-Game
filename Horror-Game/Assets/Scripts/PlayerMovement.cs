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
    public Animator anim;
    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;
    public float sneakSpeed = 5f;
    bool wPressed;
    bool aPressed;
    bool sPressed;
    bool dPressed;
    bool shiftPressed;
    bool isSprinting;
    bool isJumping;
    bool isSneaking;
    bool isWalking;

    void Start()
    {

    }

    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <= 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("isJumping", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }

        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            anim.SetBool("isJumping", false);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            wPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && isSneaking == false && direction.magnitude >= 0.1f && (wPressed == true || aPressed == true || sPressed == true || dPressed == true))
        {
            walkSpeed = sprintSpeed;
            isSprinting = true;
            anim.SetBool("isRunning", true);
            isWalking = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 10f;
            isSprinting = false;
            anim.SetBool("isRunning", false);
        }

        //Sneak
        if (Input.GetKeyDown(KeyCode.C) && isGrounded && direction.magnitude >= 0.1f)
        {
            walkSpeed = sneakSpeed;
            isSneaking = true;
            anim.SetBool("isSneaking", true);
            isWalking = false;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            walkSpeed = 10f;
            isSneaking = false;
            anim.SetBool("isSneaking", false);
        }

        //sprint if walking
        if (isWalking = true && Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }


        //Sneaking if is Walking
        if (isWalking == true && Input.GetKeyDown(KeyCode.C) && isGrounded)
        {
            anim.SetBool("isSneaking", true);
            anim.SetBool("isWalking", false);
            isSneaking = true;
        }


        //Sprinting if is Walking
        if (isWalking == true && Input.GetKeyDown(KeyCode.LeftShift) && isGrounded && isSneaking == false)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
            isSprinting = true;
        }


        //Detecting if Player is Moving
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && direction.magnitude > 0.1f || Input.GetKeyDown(KeyCode.S) && isGrounded && direction.magnitude > 0.1f || Input.GetKeyDown(KeyCode.A) && isGrounded && direction.magnitude > 0.1f || Input.GetKeyDown(KeyCode.D) && isGrounded && direction.magnitude > 0.1f)
        {
            isWalking = true;
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isWalking = false;
            anim.SetBool("isWalking", false);
        }
    }
}