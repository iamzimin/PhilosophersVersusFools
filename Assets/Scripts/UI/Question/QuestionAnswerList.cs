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
        // ---------------- ������ 1 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "������ ����� �� 1 �� 4";
        qChoice.answers = new List<string>() { "1", "2", "3", "4" };
        qChoice.rightAnswerId = 0; //������ � 0
        questionsChoice.Add(qChoice);

        // ---------------- ������ 2 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "������ ����� �� 5 �� 8";
        qChoice.answers = new List<string>() { "5", "6", "7", "8" };
        qChoice.rightAnswerId = 0; //������ � 0
        questionsChoice.Add(qChoice);

        // ---------------- ������ 3 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "������ ����� �� 9 �� 12";
        qChoice.answers = new List<string>() { "9", "10", "11", "12" };
        qChoice.rightAnswerId = 0; //������ � 0
        questionsChoice.Add(qChoice);

        // ---------------- ������ 4 ----------------
        qChoice = new QuestionChoice();
        qChoice.questionText = "������ ����� �� 13 �� 16";
        qChoice.answers = new List<string>() { "13", "14", "15", "16" };
        qChoice.rightAnswerId = 0; //������ � 0
        questionsChoice.Add(qChoice);
    }

    private void LoadQuestionEnter()
    {
        // ---------------- ������ 1 ----------------
        qEnter = new QuestionEnter();
        qEnter.questionText = "������ ����� �� 1 �� 4";
        qEnter.rightAnswer = "1"; //����� ��������� �������
        questionsEnter.Add(qEnter);

        // ---------------- ������ 2 ----------------
        qEnter = new QuestionEnter();
        qEnter.questionText = "������ ����� �� 5 �� 8";
        qEnter.rightAnswer = "6"; //����� ��������� �������
        questionsEnter.Add(qEnter);
    }


    public QuestionChoice getRandomQuestionChoice()
    {
        if (questionsChoice.Count == 0)
        {
            qChoice.questionText = "������� ����������� :((";
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
            qEnter.questionText = "������� ����������� :((";
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