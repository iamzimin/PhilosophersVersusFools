using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Violet : Enemy
{
    Hero hero;
    Enemy enemy;
    public Violet()
    {
        power = 6;
        healhPoint = 150;
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
