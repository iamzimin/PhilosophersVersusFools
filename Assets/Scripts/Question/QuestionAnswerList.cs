using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionAnswerList : MonoBehaviour
{
    public class Question
    {
        public string questionText;
        public List<string> answers;
        public int rightAnswerId;
    }
    public List<Question> questions = new List<Question>();

    public void Awake()
    {
        Question q = new Question();
        q.questionText = "Угадай число от 1 до 4";
        q.answers = new List<string>() { "1", "2", "3", "4" };
        q.rightAnswerId = 3;
        questions.Add(q);
    }

    public Question getRandomElement()
    {
        if (questions.Count == 0)
        {
            Question q = new Question();
            q.questionText = "Вопросы закончились :((";
            q.answers = new List<string>() { "", "", "", "" };
            q.rightAnswerId = 5;
            return q;
        }

        var rnd = new System.Random();
        int n = rnd.Next(0, questions.Count);

        Question output = questions[n];
        questions.RemoveAt(n);
        return output;
    }



}