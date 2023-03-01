using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{
    public Image healthBar;

    [Header("Statistics")]
    public GameObject statisticsManagerGameObject;
    public StatisticsManager statisticsManager;

    public override void GetDamage(int amountDamage)
    {
        healhPoint -= amountDamage;
        ChangeHealth();
        if (healhPoint <= 0)
            Die();
    }

    public override void Die()
    {
        statisticsManagerGameObject = GameObject.FindGameObjectWithTag("Player");
        statisticsManager = statisticsManagerGameObject.GetComponent<StatisticsManager>();
        if (statisticsManager != null)
            statisticsManager.killedFools += 1;
        base.Die();
    }

    public void ChangeHealth()
    {
        healthBar.fillAmount = (float)healhPoint / maxHealhPoint;
    }

    public void UpgradeParametrs(int damage, int hp)
    {
        base.power += damage;
        healhPoint += hp;
        maxHealhPoint = healhPoint;
    }
}
