using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnScreen : MonoBehaviour
{
    public Transform cam;
    Transform weapon;
    private void Awake()
    {
        weapon = GetComponent<Transform>();
    }
    void Update()
    {
        weapon.rotation = cam.rotation;
    }
}
