using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : Enemy
{
    public Hero hero;
    public Enemy enemy;
    public Black()
    {
        power = 10;
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
}
