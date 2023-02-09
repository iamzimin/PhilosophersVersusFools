using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject blood;
    private bool targetHit;
    public float deleteTime = 5f;
    public int damage = 50;


    private void OnCollisionEnter(Collision collision)
    {
        //if (targetHit)
        //    return;
        //else
        //    targetHit = true;

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.GetDamage(damage);

            GameObject bloodClone = Instantiate(blood, transform.position, transform.rotation);
            Destroy(bloodClone, 2);

        }
        Invoke(nameof(DeleteBook), deleteTime);
    }

    private void DeleteBook()
    {
        Destroy(gameObject);
    }
}