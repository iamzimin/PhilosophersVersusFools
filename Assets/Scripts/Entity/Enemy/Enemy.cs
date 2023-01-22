using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Entity hero;
    public Entity enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == hero.gameObject)
        {
            hero.GetDamage();
        }
    }

}
