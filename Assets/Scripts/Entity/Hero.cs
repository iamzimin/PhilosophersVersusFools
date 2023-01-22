using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero : Entity
{
    //[Header("Hero parameters")]

    public Hero()
    {
        runSeed = base.runSeed;
        strafeSeed = base.strafeSeed;
        jumpForce = 1f;
        healhPoint = 50;
    }


    public override void GetDamage()
    {
        healhPoint -= 5;
        if ( healhPoint <= 0 )
        {
            Die();
        }
    }
    public override void Die()
    {
        base.Die();
    }
}
