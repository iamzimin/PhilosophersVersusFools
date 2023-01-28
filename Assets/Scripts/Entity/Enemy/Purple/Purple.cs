using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : Enemy
{
    Hero hero;
    Enemy enemy;
    public Purple()
    {
        power = 8;
        healhPoint = 110;
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
