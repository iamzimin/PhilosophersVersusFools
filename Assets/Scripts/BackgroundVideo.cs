using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundVideo : MonoBehaviour
{
    private GameObject cameraGO;
    private Camera camera;

    private VideoPlayer player;

    void Start()
    {
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
        camera = cameraGO.GetComponent<Camera>();

        player = GetComponent<VideoPlayer>();
        player.targetCamera = camera;
    }

    private void LateUpdate()
    {
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");
        camera = cameraGO.GetComponent<Camera>();

        player = GetComponent<VideoPlayer>();
        player.targetCamera = camera;
    }
}
