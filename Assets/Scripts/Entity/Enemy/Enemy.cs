using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{
    public Image healthBar;


    public override void GetDamage(int amountDamage)
    {
        healhPoint -= amountDamage;
        ChangeHealth();
        if (healhPoint <= 0)
            Die();
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
