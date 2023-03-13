using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public FirebaseDatabaseManager databaseManager;
    public GameObject gameOverGameObject;
    private CanvasGroup gameOverCanvasGroup;
    public TextMeshProUGUI[] text;
    public float lerpTime = 0f;
    public bool isShowed = false;


    public int questionsWithChoise = 0;//
    public int questionsWithEnter = 0;//

    public int killedFools = 0;//
    public double surviveTime = 0f;//

    public int booksThrown = 0;//
    public double totalRunDistance = 0f;//
    public int healthPointsSpent = 0;//
    public int wrongAnswersWithChoise = 0;//
    public int wrongAnswersWithEnter = 0;//

    public void SetStats()
    {
        gameOverGameObject.SetActive(true);

        text[0].text = questionsWithChoise.ToString();
        text[1].text = questionsWithEnter.ToString();
        text[2].text = killedFools.ToString();
        text[3].text = (wrongAnswersWithChoise + wrongAnswersWithEnter).ToString();
        text[4].text = healthPointsSpent.ToString();
        text[5].text = Math.Round(surviveTime, 0).ToString();
        text[6].text = Math.Round(totalRunDistance, 0).ToString();
        text[7].text = booksThrown.ToString();

        var data = SaveManager.Load<SaveData>(ConfigManager.saveKey);
        if (data != null)
        {
            databaseManager.AddPlayer(data.nickname, questionsWithChoise + questionsWithEnter, killedFools);
        }
    }

    public void DisableDeadScreen()
    {
        gameOverGameObject.SetActive(false);
    }

    private void Start()
    {
        gameOverCanvasGroup = gameOverGameObject.GetComponent<CanvasGroup>();
        gameOverCanvasGroup.alpha = 0f;
    }

    private void Update()
    {
        if (gameOverGameObject.activeSelf && !isShowed)
        {
            lerpTime += 0.5f * Time.deltaTime;
            gameOverCanvasGroup.alpha = Mathf.Lerp(0f, 1f, lerpTime);
            if (lerpTime > 1)
                isShowed = true;
        }
        
    }

}
