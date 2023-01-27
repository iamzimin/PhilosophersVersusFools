using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionAnswerList : MonoBehaviour
{
    public class QuestionChoice
    {
        public string questionText;
        public List<string> answers;
        public int rightAnswerId;
    }
    public class QuestionEnter
    {
        public string questionText;
        public string yourAnswer;
        public string rightAnswer;
    }

    public List<QuestionChoice> questionsChoice = new List<QuestionChoice>();
    QuestionChoice qChoice = new QuestionChoice();

    public List<QuestionEnter> questionsEnter = new List<QuestionEnter>();
    QuestionEnter qEnter = new QuestionEnter();

    private void LoadQuestionChoice()
    {
        // ---------------- ВОПРОС 1 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "Основателем этики в западноевропейской философии считаеться:";
        qChoice.answers = new List<string>() { "Аристотель", "Сократ", "Фалес", "Платон" };
        qChoice.rightAnswerId = 1; //отсчёт с 0
        questionsChoice.Add(qChoice);

        // ---------------- ВОПРОС 2 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "Все тела в мире имеют цель своего движения и развития, которая заданна Богом как причиной всех причин, считал:";
        qChoice.answers = new List<string>() { "Пиррон", "Зенон", "Аристотель", "Диоген" };
        qChoice.rightAnswerId = 2; //отсчёт с 0
        questionsChoice.Add(qChoice);

        // ---------------- ВОПРОС 3 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "\"В одну и туже реку нельзя войти дважды\", - говорил:";
        qChoice.answers = new List<string>() { "Гераклит", "Левкипп", "Фалес", "Анаксимандр" };
        qChoice.rightAnswerId = 0; //отсчёт с 0
        questionsChoice.Add(qChoice);

        // ---------------- ВОПРОС 4 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "Наиболее известна и исторически значима в системе Эпикура:";
        qChoice.answers = new List<string>() { "Гносеология", "Онтология", "Физика", "Этика" };
        qChoice.rightAnswerId = 3; //отсчёт с 0
        questionsChoice.Add(qChoice);

        
    }

    private void LoadQuestionEnter()
    {
        // ---------------- ВОПРОС 1 ----------------
        qEnter = new QuestionEnter();
        qEnter.questionText = "Какой древнегреческий мыслитель считал, что главная задача состоит в самопознании";
        qEnter.rightAnswer = "сократ"; //ответ строчными буквами
        questionsEnter.Add(qEnter);

        // ---------------- ВОПРОС 2 ----------------
        qEnter = new QuestionEnter();
        qEnter.questionText = "Какой древнегреческий философ считал огонь основой всего";
        qEnter.rightAnswer = "Гераклит"; //ответ строчными буквами
        questionsEnter.Add(qEnter);
    }


    public QuestionChoice getRandomQuestionChoice()
    {
        if (questionsChoice.Count == 0)
        {
            qChoice.questionText = "Вопросы закончились :((";
            qChoice.answers = new List<string>() { "", "", "", "" };
            qChoice.rightAnswerId = -1;
            return qChoice;
        }

        var rnd = new System.Random();
        int n = rnd.Next(0, questionsChoice.Count);

        qChoice = questionsChoice[n];
        questionsChoice.RemoveAt(n);
        return qChoice;
    }

    public QuestionEnter getRandomQuestionEnter()
    {
        if (questionsEnter.Count == 0)
        {
            qEnter.questionText = "Вопросы закончились :((";
            qEnter.rightAnswer = "";
            return qEnter;
        }

        var rnd = new System.Random();
        int n = rnd.Next(0, questionsEnter.Count);

        qEnter = questionsEnter[n];
        questionsEnter.RemoveAt(n);
        return qEnter;
    }


    public void Start()
    {
        LoadQuestionChoice();
        LoadQuestionEnter();
    }



}