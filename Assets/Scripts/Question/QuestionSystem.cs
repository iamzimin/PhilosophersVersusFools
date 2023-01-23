using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static QuestionAnswerList;

public class QuestionSystem : MonoBehaviour
{
    public Canvas canvas;
    
    public Image questionLayer;
    public Image winLayer;
    public Image loseLayer;

    public TextMeshProUGUI questionText;

    public TextMeshProUGUI[] answersText = new TextMeshProUGUI[4];

    private QuestionAnswerList qaList;
    QuestionAnswerList.Question q;

    private void Start()
    {
        qaList = GetComponent<QuestionAnswerList>();

        canvas.gameObject.SetActive(false);
        questionLayer.gameObject.SetActive(false);
        winLayer.gameObject.SetActive(false);
        loseLayer.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void ActivateQuestion()
    {
        canvas.gameObject.SetActive(true);
        questionLayer.gameObject.SetActive(true);

        q = qaList.getRandomElement();

        questionText.text = q.questionText;

        for (int i = 0; i < answersText.Length; i++)
            answersText[i].text = q.answers[i];

    }

    public void DeactivateQuestion() //fixme fix me todo to do delete
    {
        canvas.gameObject.SetActive(false);
        questionLayer.gameObject.SetActive(false);
        winLayer.gameObject.SetActive(false);
        loseLayer.gameObject.SetActive(false);
    }

    public void OnClickButton(int numBtn)
    {
        questionLayer.gameObject.SetActive(false);
        if (q.rightAnswerId == numBtn)
            winLayer.gameObject.SetActive(true);
        else
            loseLayer.gameObject.SetActive(true);            
    }


}
