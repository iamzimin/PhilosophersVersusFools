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
        qChoice.questionText = "Угадай число от 1 до 4";
        qChoice.answers = new List<string>() { "1", "2", "3", "4" };
        qChoice.rightAnswerId = 0; //отсчёт с 0
        questionsChoice.Add(qChoice);

        // ---------------- ВОПРОС 2 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "Угадай число от 5 до 8";
        qChoice.answers = new List<string>() { "5", "6", "7", "8" };
        qChoice.rightAnswerId = 0; //отсчёт с 0
        questionsChoice.Add(qChoice);

        // ---------------- ВОПРОС 3 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "Угадай число от 9 до 12";
        qChoice.answers = new List<string>() { "9", "10", "11", "12" };
        qChoice.rightAnswerId = 0; //отсчёт с 0
        questionsChoice.Add(qChoice);

        // ---------------- ВОПРОС 4 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "Угадай число от 13 до 16";
        qChoice.answers = new List<string>() { "13", "14", "15", "16" };
        qChoice.rightAnswerId = 0; //отсчёт с 0
        questionsChoice.Add(qChoice);
    }

    private void LoadQuestionEnter()
    {
        // ---------------- ВОПРОС 1 ----------------
        qEnter = new QuestionEnter();
        qEnter.questionText = "Угадай число от 1 до 4";
        qEnter.rightAnswer = "1"; //ответ строчными буквами
        questionsEnter.Add(qEnter);

        // ---------------- ВОПРОС 2 ----------------
        qEnter = new QuestionEnter();
        qEnter.questionText = "Угадай число от 5 до 8";
        qEnter.rightAnswer = "6"; //ответ строчными буквами
        questionsEnter.Add(qEnter);
    }


    public QuestionChoice getRandomQuestionChoice()
    {
        if (questionsChoice.Count == 0)
        {
            qChoice.questionText = "Вопросы закончились :((";
            qChoice.answers = new List<string>() { "", "", "", "" };
            qChoice.rightAnswerId = 5;
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