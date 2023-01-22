using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float groundDrag;
    public float jumpForce = 5f;
    public float jumpCooldown = 1f;
    public float airMultiplier = 5f;
    bool isRedyToJump = true;



    [Header("Ground Check")]
    public float playerHight = 2f;
    public float groundDistance = 0.2f;
    public LayerMask whatIsGround;
    bool isGrounded;

    public Transform orientation;
    public Transform groundCheck;


    float x;
    float z;
    Rigidbody rb;
    Vector3 moveDirection;
    Vector3 rotateDirection;

    private void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Jump") && isRedyToJump && isGrounded)
        {
            isRedyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer()
    {
        moveDirection = orientation.right * x + orientation.forward * z;

        rb.MoveRotation(orientation.rotation);

        
        if (isGrounded)
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        else
            rb.AddForce(moveDirection.normalized * speed * airMultiplier, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y , limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        isRedyToJump = true;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHight * 0.5f, whatIsGround);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        MyInput();
        SpeedControl();
        //MovePlayer();

        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


        /*
        ////if (rigidbody.velocity.y == 0f)
        //rigidbody.velocity = move * speed * Time.deltaTime;
        ////else
        //    //rigidbody.velocity = move * Time.deltaTime;

        //controller.Move(rigidbody.velocity);

        ////velocity.y += gravity * Time.deltaTime;

        ////controller.Move(velocity * Time.deltaTime);

        ////if (Input.GetButtonDown("Jump") && isGrounded)
        ////    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        //if (Input.GetButtonDown("Jump") && rigidbody.velocity.y < 0f)
        //    rigidbody.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        //velocityY = rigidbody.velocity.y;

        //if (Input.GetKey("left shift"))
        //    speed = 10f;
        //else
        //    speed = 5f;
        */
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
