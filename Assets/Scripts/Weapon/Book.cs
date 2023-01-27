using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject blood;
    private bool targetHit;
    public int damage = 50;
    public float deleteTime = 5f;
    //public int deleteBookTime = 2;


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



            GameObject bloodClone = Instantiate(blood, transform.position, transform.rotation);
            Destroy(bloodClone, 2);

            //Destroy(gameObject);

        }
        Invoke(nameof(DeleteBook), deleteTime);
        //transform.SetParent(parent.transform);

        //transform.SetParent(collision.transform);
        //Destroy(gameObject);
    }

    private void DeleteBook()
    {
        Destroy(gameObject);
    }
}