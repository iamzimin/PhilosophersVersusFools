using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows = 10;
    public float throwCooldown = 0.5f;
    public bool isPause = false;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce = 1f;
    public float throwUpwardForce = 1f;

    bool isReadyToThrow;

    private void Start()
    {
        isReadyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && isReadyToThrow && totalThrows > 0 && !isPause)
            Throw();
    }

    private void Throw()
    {
        isReadyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 1000f))
            forceDirection = (hit.point - attackPoint.position).normalized;

        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        //totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        isReadyToThrow = true;
    }

}