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

    public TextMeshProUGUI questionTextChoice;
    public TextMeshProUGUI[] answersTextChoice = new TextMeshProUGUI[4];


    [Header("QuestionWithEnter")]
    public Image questionLayerEnter;
    public Image winLayerEnter;
    public Image loseLayerEnter;

    public TextMeshProUGUI questionTextEnter;
    public TMP_InputField answerTextEnter;




    private QuestionAnswerList qaList;
    private QuestionAnswerList.QuestionChoice qChoice;
    private QuestionAnswerList.QuestionEnter qEnter;

    private void Start()
    {
        qaList = GetComponent<QuestionAnswerList>();

        DeactivateQuestions();
    }
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
        canvas.gameObject.SetActive(true);
        questionLayerChoice.gameObject.SetActive(true);

        qChoice = qaList.getRandomQuestionChoice();

        questionTextChoice.text = qChoice.questionText;

        for (int i = 0; i < answersTextChoice.Length; i++)
            answersTextChoice[i].text = qChoice.answers[i];
    } 
    
    public void ActivateQuestionEnter()
    {
        canvas.gameObject.SetActive(true);
        questionLayerEnter.gameObject.SetActive(true);

        qEnter = qaList.getRandomQuestionEnter();

        questionTextEnter.text = qEnter.questionText;       
    }


    public void OnClickButtonChoice(int numBtn)
    {
        questionLayerChoice.gameObject.SetActive(false);
        if (qChoice.rightAnswerId == numBtn)
            winLayerChoice.gameObject.SetActive(true);
        else
            loseLayerChoice.gameObject.SetActive(true);            
    }
    public void OnClickButtonEnter()
    {
        questionLayerEnter.gameObject.SetActive(false);

        string s1 = answerTextEnter.text.ToString().ToLower();
        string s2 = qEnter.rightAnswer.ToString().ToLower();

        if (!s1.Equals(""))
        {
            if (Equals(s1, s2))
                winLayerEnter.gameObject.SetActive(true);
            else
                loseLayerEnter.gameObject.SetActive(true);
        }


        answerTextEnter.text = "";
    }


}
