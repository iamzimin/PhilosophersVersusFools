using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static QuestionAnswerList;
using Unity.VisualScripting;

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


    [Header("QuestionWithEnter")]
    public Image questionLayerEnter;
    public Image winLayerEnter;
    public Image loseLayerEnter;

    public TextMeshProUGUI[] questionTextEnter = new TextMeshProUGUI[3];
    public TextMeshProUGUI rewardTextEnter;
    public TMP_InputField answerTextEnter;

    public TextMeshProUGUI[] compareYourEnter = new TextMeshProUGUI[2];
    public TextMeshProUGUI[] compareRightEnter = new TextMeshProUGUI[2];

    [Header("Hero")]
    //public Hero hero;
    public CoinsManager coinsManager;


    private QuestionAnswerList qaList;
    private QuestionAnswerList.QuestionChoice qChoice;
    private QuestionAnswerList.QuestionEnter qEnter;

    private int rewardChoice = 10;
    private int rewardEnter = 50;

    private string yourAnswer = "Ваш ответ: ";
    private string rightAnswer = "Правильный ответ: ";




    public void DeactivateQuestions()
    {
        canvas.gameObject.SetActive(false);

        questionLayerChoice.gameObject.SetActive(false);
        winLayerChoice.gameObject.SetActive(false);
        loseLayerChoice.gameObject.SetActive(false);

        questionLayerEnter.gameObject.SetActive(false);
        winLayerEnter.gameObject.SetActive(false);
        loseLayerEnter.gameObject.SetActive(false);
    }

    public void ActivateQuestionChoice()
    {
        coinsManager.UpdateCoins();

        canvas.gameObject.SetActive(true);
        questionLayerChoice.gameObject.SetActive(true);

        qChoice = qaList.getRandomQuestionChoice();

        for (int i = 0; i < questionTextChoice.Length; i++)
            questionTextChoice[i].text = qChoice.questionText;

        for (int i = 0; i < answersTextChoice.Length; i++)
            answersTextChoice[i].text = qChoice.answers[i];
    } 
    
    public void ActivateQuestionEnter()
    {
        coinsManager.UpdateCoins();

        canvas.gameObject.SetActive(true);
        questionLayerEnter.gameObject.SetActive(true);

        qEnter = qaList.getRandomQuestionEnter();

        for (int i = 0; i < questionTextEnter.Length; i++)
            questionTextEnter[i].text = qEnter.questionText;
    }


    public void OnClickButtonChoice(int numBtn)
    {
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
            compareYourChoice[i].text = yourAnswer + answersTextChoice[numBtn].text;

        for (int i = 0; i < compareRightChoice.Length; i++)
            compareRightChoice[i].text = rightAnswer + answersTextChoice[qChoice.rightAnswerId].text;
    }

    public void OnClickButtonEnter()
    {
        questionLayerEnter.gameObject.SetActive(false);

        string s1 = answerTextEnter.text.ToString().ToLower();
        string s2 = qEnter.rightAnswer.ToString().ToLower();

        UpdateCompareEnter();

        if (!s1.Equals(""))
        {
            if (Equals(s1, s2))
            {
                coinsManager.AddCoinsToPlayer(rewardEnter);
                coinsManager.UpdateCoins();
                winLayerEnter.gameObject.SetActive(true);
            }
            else
                loseLayerEnter.gameObject.SetActive(true);
        }


        answerTextEnter.text = "";
    }
    private void UpdateCompareEnter()
    {
        for (int i = 0; i < compareYourEnter.Length; i++)
            compareYourEnter[i].text = yourAnswer + answerTextEnter.text.ToString();

        for (int i = 0; i < compareRightEnter.Length; i++)
            compareRightEnter[i].text = rightAnswer + qEnter.rightAnswer.ToString().ToLower();
    }

    private void Start()
    {
        qaList = GetComponent<QuestionAnswerList>();

        DeactivateQuestions();

        rewardTextChoice.text = rewardChoice.ToString();
        rewardTextEnter.text = rewardEnter.ToString();
    }
}
