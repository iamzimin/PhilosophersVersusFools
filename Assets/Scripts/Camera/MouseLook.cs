using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform orientation;

    public float mouseSensetivityX = 500f;
    public float mouseSensetivityY = 500f;
    float rotationX = 0f;
    float rotationY = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivityX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivityY * Time.deltaTime;

        rotationY += mouseX;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        if (transform != null && orientation != null)
        {
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
            orientation.rotation = Quaternion.Euler(0, rotationY, 0);
        }
    }
}
