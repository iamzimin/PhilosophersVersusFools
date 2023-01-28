using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform orientation;

    public float mouseSensetivityX = 500f;
    public float mouseSensetivityY = 500f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    private float mouseX;
    private float mouseY;

    public bool isPause = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!isPause)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensetivityX * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensetivityY * Time.deltaTime;
        }
        else
        {
            mouseX = 0f;
            mouseY = 0f;
        }
        

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
