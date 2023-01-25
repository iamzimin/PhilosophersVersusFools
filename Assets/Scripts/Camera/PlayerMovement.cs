using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Hero hero;

    [Header("Movement")]
    private float speed;
    private float normalSpeed;
    private float strafeSpeed;
    private float groundDrag;
    private float jumpForce;
    private float jumpCooldown;
    private float airMultiplier;
    public bool isRedyToJump = true;



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

        if (Input.GetKey(KeyCode.LeftShift))
            speed = strafeSpeed;
        else
            speed = normalSpeed;
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
    
    public void UpdateCharacteristics()
    {
        speed = hero.speed;
        normalSpeed = speed;
        strafeSpeed = hero.strafeSpeed;
        groundDrag = hero.groundDrag;
        jumpForce = hero.jumpForce;
        jumpCooldown = hero.jumpCooldown;
        airMultiplier = hero.airMultiplier;
    }

    private void Start()
    {
        UpdateCharacteristics();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        UpdateCharacteristics(); //fixme

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        MyInput();
        SpeedControl();

        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
}
