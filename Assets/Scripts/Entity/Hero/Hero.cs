using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero : Entity
{
    public float speed;
    public float strafeSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    public int coins;


    public Hero()
    {
        healhPoint = 500;
    }

    public int getPower()
    {
        return power;
    }

    private void Start()
    {
        speed = 20f;
        strafeSpeed = speed + speed / 2;
        groundDrag = 1f;
        jumpForce = 5f;
        jumpCooldown = 1f;
        airMultiplier = 0f;

        coins = 100;
    }
}