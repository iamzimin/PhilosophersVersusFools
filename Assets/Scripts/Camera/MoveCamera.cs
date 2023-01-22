using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Update()
    {
        if (transform != null && cameraPosition != null)
            transform.position = cameraPosition.position;
    }
}
