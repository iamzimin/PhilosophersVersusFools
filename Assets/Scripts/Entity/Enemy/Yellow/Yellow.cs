using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Enemy
{
    Hero hero;
    Enemy enemy;
    public Yellow()
    {
        power = 7;
        healhPoint = 50;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hero != null && collision.gameObject == hero.gameObject)
        {
            hero.GetDamage(power);
            enemy.GetDamage(hero.getPower());
        }
    }

    public void Start()
    {
        hero = FindObjectOfType<Hero>();
        enemy = GetComponent<Enemy>();
    }
}
