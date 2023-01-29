using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static QuestionAnswerList;
using Unity.VisualScripting;
using System;

public class QuestionSystem : MonoBehaviour
{
    public Canvas canvas;

    [Header("QuestionWithChoice")]
    public Image questionLayerChoice;
    public Image winLayerChoice;
    public Image loseLayerChoice;

    public TextMeshProUGUI[] questionTextChoice = new TextMeshProUGUI[3];
    public TextMeshProUGUI rewardTextChoice;
    public TextMeshProUGUI[] answersTextChoice = new TextMeshProUGUI[4];

    public TextMeshProUGUI[] compareYourChoice = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] compareRightChoice = new TextMeshProUGUI[2];

    public TextMeshProUGUI timeTextChoice;
    [SerializeField] private bool isPickChoice = false;
    [SerializeField] private float timerChoice = 5f;
    [SerializeField] private float timeChoice = 5f;


    [Header("QuestionWithEnter")]
    public Image questionLayerEnter;
    public Image winLayerEnter;
    public Image loseLayerEnter;

    public TextMeshProUGUI[] questionTextEnter = new TextMeshProUGUI[3];
    public TextMeshProUGUI rewardTextEnter;
    public TMP_InputField answerTextEnter;

    public TextMeshProUGUI[] compareYourEnter = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] compareRightEnter = new TextMeshProUGUI[2];

    public TextMeshProUGUI timeTextEnter;
    [SerializeField] private bool isPickEnter = false;
    [SerializeField] private float timerEnter = 6f;
    [SerializeField] private float timeEnter = 6f;


    [Header("BothQuestions")]
    public QuestionTimer questionTimer;
    public Image noQuestions;
    public int rewardChoice = 10;
    public int rewardEnter = 50;

    [Header("Hero")]
    public CoinsManager coinsManager;
    public PauseGame pauseGame;


    private QuestionAnswerList qaList;
    private QuestionAnswerList.QuestionChoice qChoice;
    private QuestionAnswerList.QuestionEnter qEnter;


    private string yourAnswerString = "Ваш ответ: ";
    private string rightAnswerString = "Правильный ответ: ";
    private string timeString = "Осталось: ";




    public void DeactivateQuestions(bool isEmpty)
    {
        pauseGame.ResumeGame();

        questionLayerChoice.gameObject.SetActive(false);
        winLayerChoice.gameObject.SetActive(false);
        loseLayerChoice.gameObject.SetActive(false);

        questionLayerEnter.gameObject.SetActive(false);
        winLayerEnter.gameObject.SetActive(false);
        loseLayerEnter.gameObject.SetActive(false);

        noQuestions.gameObject.SetActive(false);

        questionTimer.isInQuestion = false;

        if (!isEmpty)
            questionTimer.ResetTime();

        RestartTime();
        ResetPick();
    }

    public void ActivateQuestionChoice()
    {
        pauseGame.StopGame();

        isPickChoice = true;
        coinsManager.UpdateCoins();

        qChoice = qaList.getRandomQuestionChoice();

        if (qChoice.rightAnswerId == -1)
        {
            noQuestions.gameObject.SetActive(true);
            return;
        }

        questionLayerChoice.gameObject.SetActive(true);        

        for (int i = 0; i < questionTextChoice.Length; i++)
            questionTextChoice[i].text = qChoice.questionText;

        for (int i = 0; i < answersTextChoice.Length; i++)
            answersTextChoice[i].text = qChoice.answers[i];
    } 
    
    public void ActivateQuestionEnter()
    {
        pauseGame.StopGame();

        isPickEnter = true;
        coinsManager.UpdateCoins();

        qEnter = qaList.getRandomQuestionEnter();

        if (qEnter.rightAnswer == "")
        {
            noQuestions.gameObject.SetActive(true);
            return;
        }

        questionLayerEnter.gameObject.SetActive(true);

        for (int i = 0; i < questionTextEnter.Length; i++)
            questionTextEnter[i].text = qEnter.questionText;
    }


    public void OnClickButtonChoice(int numBtn)
    {
        RestartTime();
        ResetPick();

        questionLayerChoice.gameObject.SetActive(false);

        UpdateCompareChoice(numBtn);

        if (qChoice.rightAnswerId == numBtn)
        {
            coinsManager.AddCoinsToPlayer(rewardChoice);
            coinsManager.UpdateCoins();
            winLayerChoice.gameObject.SetActive(true);
        }
        else
            loseLayerChoice.gameObject.SetActive(true);
    }

    private void UpdateCompareChoice(int numBtn)
    {
        for (int i = 0; i < compareYourChoice.Length; i++)
            compareYourChoice[i].text = yourAnswerString + answersTextChoice[numBtn].text;

        for (int i = 0; i < compareRightChoice.Length; i++)
            compareRightChoice[i].text = rightAnswerString + answersTextChoice[qChoice.rightAnswerId].text;
    }

    public void OnClickButtonEnter()
    {
        RestartTime();
        ResetPick();

        questionLayerEnter.gameObject.SetActive(false);

        string s1 = answerTextEnter.text.ToString().ToLower();
        string s2 = qEnter.rightAnswer.ToString().ToLower();

        UpdateCompareEnter();

        if (Equals(s1, s2))
        {
            coinsManager.AddCoinsToPlayer(rewardEnter);
            coinsManager.UpdateCoins();
            winLayerEnter.gameObject.SetActive(true);
        }
        else
            loseLayerEnter.gameObject.SetActive(true);


        answerTextEnter.text = "";
    }
    private void UpdateCompareEnter()
    {
        for (int i = 0; i < compareYourEnter.Length; i++)
            compareYourEnter[i].text = yourAnswerString + answerTextEnter.text.ToString();

        for (int i = 0; i < compareRightEnter.Length; i++)
            compareRightEnter[i].text = rightAnswerString + qEnter.rightAnswer.ToString().ToLower();
    }

    private void TimeEndChoice()
    {
        for (int i = 0; i < compareYourChoice.Length; i++)
            compareYourChoice[i].text = yourAnswerString;

        for (int i = 0; i < compareRightChoice.Length; i++)
            compareRightChoice[i].text = rightAnswerString + answersTextChoice[qChoice.rightAnswerId].text;

        loseLayerChoice.gameObject.SetActive(true);
    }

    private void TimeEndEnter()
    {
        for (int i = 0; i < compareYourEnter.Length; i++)
            compareYourEnter[i].text = yourAnswerString;

        for (int i = 0; i < compareRightEnter.Length; i++)
            compareRightEnter[i].text = rightAnswerString + qEnter.rightAnswer.ToString().ToLower();

        loseLayerEnter.gameObject.SetActive(true);
    }

    private void RestartTime()
    {
        timeChoice = timerChoice;
        timeEnter = timerEnter;
    }
    private void ResetPick()
    {
        isPickChoice = false;
        isPickEnter = false;
    }



    private void Start()
    {
        qaList = GetComponent<QuestionAnswerList>();

        DeactivateQuestions(false);

        rewardTextChoice.text = rewardChoice.ToString();
        rewardTextEnter.text = rewardEnter.ToString();
    }

    private void Update()
    {

        if (isPickChoice)
        {
            timeChoice -= Time.deltaTime;
            timeTextChoice.text = timeString + Math.Round(timeChoice, 0).ToString();
            if (timeChoice < 0)
            {
                TimeEndChoice();

                RestartTime();
                ResetPick();
            }
        }
        else if (isPickEnter) 
        {
            timeEnter -= Time.deltaTime;
            timeTextEnter.text = timeString + Math.Round(timeEnter, 0).ToString();
            if (timeEnter < 0)
            {
                TimeEndEnter();

                RestartTime();
                ResetPick();
            }
        }

    }
}
