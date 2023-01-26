using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    TextMeshProUGUI fpsText;

    private float poolingTime = 1f;
    private float time;
    private float frameCount;

    void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= poolingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = "FPS " + frameRate.ToString();
        }
    }
}
