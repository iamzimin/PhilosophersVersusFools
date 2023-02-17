using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : Enemy
{
    Hero hero;
    Enemy enemy;
    public White()
    {
        power = 7;
        healhPoint = 50;
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
