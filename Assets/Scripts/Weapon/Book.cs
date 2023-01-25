using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private Rigidbody rb;
    private bool targetHit;
    public int damage;
    //public int deleteBookTime = 2;

    private void Start()
    {
        damage = 20;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetHit)
            return;
        else
            targetHit = true;

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.GetDamage(damage);

            //Destroy(gameObject);

        }
        transform.SetParent(collision.transform);
    }

}