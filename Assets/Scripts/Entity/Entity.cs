using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Entity parameters")]
    public int healhPoint = 100;
    public int power = 0;

    public virtual void GetDamage(int amountDamage)
    {
        healhPoint -= amountDamage;
        if (healhPoint <= 0)
            Die();
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (healhPoint <= 0)
            Die();
    }
}
