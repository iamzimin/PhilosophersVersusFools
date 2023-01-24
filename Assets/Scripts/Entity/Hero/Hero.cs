using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero : Entity
{
    public int coins;
    public Hero()
    {
        healhPoint = 500;
    }

    public int getPower()
    {
        return power;
    }

    private void Start()
    {
        coins = 100;
    }
}
