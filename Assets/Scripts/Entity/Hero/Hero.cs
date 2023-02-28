using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class Hero : Entity
{
    public PauseGame pauseGame;
    public TextMeshProUGUI healthText;
    public CanvasGroup redScreen;

    public float speed;
    public float strafeSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    public int coins;

    public string healthString = "Çהמנמגüו: ";

    private bool isGetDamage = false;
    public float lerpTime = 0f;


    public Hero()
    {
        healhPoint = 500;
        maxHealhPoint = healhPoint;
    }

    public override void GetDamage(int amountDamage)
    {
        healhPoint -= amountDamage;

        float health = ((float)healhPoint / (float)maxHealhPoint) * 100;
        if (health > 0)
            healthText.text = healthString + (Math.Round(health, 0)).ToString() + "%";
        else
            healthText.text = healthString + "0%";


        if (healhPoint <= 0)
        {
            pauseGame.StopGame();
            Die();
        }
        else
        {
            isGetDamage = true;
            redScreen.alpha = 0.7f;
        }
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

        float health = ((float)healhPoint / (float)maxHealhPoint) * 100;
        healthText.text = healthString + (Math.Round(health, 0)).ToString() + "%";
    }

    private void Update()
    {
        if (isGetDamage)
        {
            lerpTime += 3f * Time.deltaTime;
            redScreen.alpha = Mathf.Lerp(0.7f, 0, lerpTime);
            if (lerpTime > 1)
            {
                isGetDamage = false;
                lerpTime = 0;
            }
        }
    }
}
