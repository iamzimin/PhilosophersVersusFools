using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    public GameObject managerObjects;

    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject[] objectsToThrow;

    [Header("Settings")]
    public int totalThrows = 10;
    public float throwCooldown = 0.5f;
    public bool isPause = false;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce = 15f;
    public float throwUpwardForce = 1f;

    bool isReadyToThrow;

    [Header("Statistics")]
    public StatisticsManager statisticsManager;

    [Header("Sounds")]
    private PlaySound playSound;

    private void Start()
    {
        isReadyToThrow = true;
        playSound = managerObjects.GetComponent<PlaySound>();
    }

    private void Update()
    {
        if (Input.GetKey(throwKey) && isReadyToThrow && totalThrows > 0 && !isPause)
            Throw();
    }

    private void Throw()
    {

        isReadyToThrow = false;
        playSound.SoundPlay("book_throw");
        GameObject projectile = Instantiate(objectsToThrow[new System.Random().Next(0, objectsToThrow.Length)],
                                            attackPoint.position, cam.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 1000f))
            forceDirection = (hit.point - attackPoint.position).normalized;

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        //totalThrows--;
        statisticsManager.booksThrown++;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        isReadyToThrow = true;
    }

}