using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    public bool isPause = false;

    void Update()
    {
        if (transform != null && cameraPosition != null && !isPause)
            transform.position = cameraPosition.position;
    }
}
