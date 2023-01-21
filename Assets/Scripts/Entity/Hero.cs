using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero : Entity
{
    [Header("Hero parameters")]
    //[SerializeField] private GameObject hero;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private bool strafeLeft = false;
    [SerializeField] private bool strafeRight = false;
    [SerializeField] private bool strafeBack = false;
    [SerializeField] private bool strafeStraight = false;
    [SerializeField] private bool isJump = false;

    public Hero()
    {
        runSeed = base.runSeed;
        strafeSeed = base.strafeSeed;
        jumpForce = 1f;
        healhPoint = base.healhPoint;
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJump = false;
    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("a"))
            strafeLeft = true;
        else
            strafeLeft = false;

        if (Input.GetKey("d"))
            strafeRight = true;
        else
            strafeRight = false;

        if (Input.GetKey("s"))
            strafeBack = true;
        else
            strafeBack = false;

        if (Input.GetKey("w"))
            strafeStraight = true;
        else
            strafeStraight = false;

        if (Input.GetButton("Jump"))
            isJump = true;
    }

    private void FixedUpdate()
    {
        
        if (strafeLeft)
            rb.AddForce(-strafeSeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (strafeRight)
            rb.AddForce(strafeSeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (strafeBack)
            rb.AddForce(0, 0, -strafeSeed * Time.deltaTime, ForceMode.VelocityChange);

        if (strafeStraight)
            rb.AddForce(0, 0, strafeSeed * Time.deltaTime, ForceMode.VelocityChange);

        if (isJump)
            Jump();

    }
}
