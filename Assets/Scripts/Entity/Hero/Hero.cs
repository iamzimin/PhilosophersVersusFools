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
    public GameObject redScreen;
    private CanvasGroup redScreenCanvasGroup;
    public GameObject deadScreen;

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

    [Header("Statistics")]
    public StatisticsManager statisticsManager;
    private float prevPosX = 0f;
    private float prevPosZ = 0f;

    public Hero()
    {
        healhPoint = 500;
        maxHealhPoint = healhPoint;
    }

    public override void GetDamage(int amountDamage)
    {
        healhPoint -= amountDamage;
        statisticsManager.healthPointsSpent += amountDamage;

        float health = ((float)healhPoint / (float)maxHealhPoint) * 100;
        if (health > 0)
            healthText.text = healthString + (Math.Round(health, 0)).ToString() + "%";
        else
            healthText.text = healthString + "0%";


        if (healhPoint <= 0)
        {
            statisticsManager.SetStats();
            deadScreen.SetActive(true);
            pauseGame.StopGame();
            Die();
        }
        else
        {
            isGetDamage = true;
            redScreen.SetActive(isGetDamage);
            redScreenCanvasGroup.alpha = 0.7f;
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

        statisticsManager.DisableDeadScreen();
        redScreenCanvasGroup = redScreen.GetComponent<CanvasGroup>();
        prevPosX = this.transform.position.x;
        prevPosZ = this.transform.position.z;
    }

    private void Update()
    {
        if (isGetDamage)
        {
            lerpTime += 3f * Time.deltaTime;
            redScreenCanvasGroup.alpha = Mathf.Lerp(0.7f, 0, lerpTime);
            if (lerpTime > 1)
            {
                isGetDamage = false;
                redScreen.SetActive(isGetDamage);
                lerpTime = 0;
            }
        }
        statisticsManager.surviveTime += Time.deltaTime;
        statisticsManager.totalRunDistance += Math.Sqrt(Math.Pow(this.transform.position.x - prevPosX, 2) + Math.Pow(this.transform.position.z - prevPosZ, 2));
        prevPosX = this.transform.position.x;
        prevPosZ = this.transform.position.z;
    }
}
