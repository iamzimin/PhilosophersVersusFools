using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionTimer : MonoBehaviour
{
    [SerializeField] private float timer = 5;
    public TextMeshProUGUI timerText;

    private string myText = "До следующего вопроса: ";
    private string readyText = "Вопрос готов";
    private float time = 5;

    public bool isReady;
    public bool isInQuestion;

    public float GetTime()
    {
        return time;
    }

    public void ResetTime()
    {
        time = timer;
    }

    void Update()
    {
        if (!isInQuestion)
            time -= Time.deltaTime;

        isReady = 0 > time;

        if (!isReady)
            timerText.text = myText + Math.Round(time, 0).ToString();
        else
            timerText.text = readyText;

        
    }
}
