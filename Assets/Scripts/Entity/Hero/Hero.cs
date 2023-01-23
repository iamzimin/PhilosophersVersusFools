using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Hero : Entity
{
    public Hero()
    {
        healhPoint = 500;
    }

    public int getPower()
    {
        return power;
    }
}
