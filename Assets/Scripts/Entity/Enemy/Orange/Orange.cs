using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Enemy
{
    Hero hero;
    Enemy enemy;
    public Orange()
    {
        power = 9;
        healhPoint = 120;
        maxHealhPoint = healhPoint;
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
