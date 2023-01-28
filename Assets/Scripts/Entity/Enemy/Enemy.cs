using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Enemy()
    {
        healhPoint = base.healhPoint;
    }

    public void UpgradeParametrs(int damage, int hp)
    {
        base.power += damage;
        healhPoint += hp;
    }
}
