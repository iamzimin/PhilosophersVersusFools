using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static QuestionAnswerList;

public class QuestionSystem : MonoBehaviour
{
    public Canvas canvas;
    
    public Image questionLayer;
    public Image endLayer;

    public TextMeshProUGUI questionText;

    public TextMeshProUGUI[] answersText = new TextMeshProUGUI[4];

    private QuestionAnswerList qaList;

    private void Start()
    {
        qaList = GetComponent<QuestionAnswerList>();
        

    }

    void Update()
    {

    }

    public void ActivateQuestion()
    {
        canvas.gameObject.SetActive(true);
        questionLayer.gameObject.SetActive(true);

        QuestionAnswerList.Question q;
        q = qaList.getRandomElement();

        questionText.text = q.questionText;

        for (int i = 0; i < answersText.Length; i++)
            answersText[i].text = q.answers[i];

    }



}
