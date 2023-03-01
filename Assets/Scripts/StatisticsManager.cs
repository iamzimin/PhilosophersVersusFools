using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public GameObject gameOverGameObject;
    public TextMeshProUGUI[] text;


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
        text[5].text = surviveTime.ToString();
        text[6].text = totalRunDistance.ToString();
        text[7].text = booksThrown.ToString();
    }

    public void DisableDeadScreen()
    {
        gameOverGameObject.SetActive(false);
    }

}
