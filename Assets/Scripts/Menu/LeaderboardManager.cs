using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public FirebaseDatabaseManager databaseManager;
    public List<Dictionary<string, object>> leaderboard;
    public GameObject leaderboard_row;
    public GameObject ScrollView;

    void Start()
    {
        databaseManager.StartCoroutine(databaseManager.GetDataFromFirebase());
        //databaseManager.GetDataFromFirebase();
        //this.leaderboard = databaseManager.leaderboard;
    }

    public void FillScrolView()
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            /*string nickname = "";
            int score = 0;
            int kills = 0;
            int time = 0;
            int distance = 0;
            int books = 0;*/


            string nickname = (string)leaderboard[i]["nickname"];
            int score = Convert.ToInt32(leaderboard[i]["score"]);
            int kills = Convert.ToInt32(leaderboard[i]["kills"]);
            int time = Convert.ToInt32(leaderboard[i]["time"]);
            int distance = Convert.ToInt32(leaderboard[i]["distance"]);
            int books = Convert.ToInt32(leaderboard[i]["books"]);

            Debug.Log(nickname + score.ToString() + kills.ToString() + time.ToString() + distance.ToString() + books.ToString());

            Debug.Log(ScrollView.transform.position.ToString());
            Debug.Log(leaderboard_row.ToString());
            Debug.Log(transform.rotation.ToString());

            GameObject row = Instantiate(leaderboard_row, ScrollView.transform.position, transform.rotation);
            row.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = nickname;
            row.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = score.ToString();
            row.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = kills.ToString();
            row.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = time.ToString();
            row.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = distance.ToString();
            row.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = books.ToString();

            row.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "¹" + (i + 1).ToString();

            if (i == 0)
            {
                row.transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color(0.8f, 0.67f, 0f, 1f);
            }
            else if (i == 1)
            {
                row.transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color(0.6f, 0.6f, 0.6f, 1f);
            } 
            else if (i == 2)
            {
                row.transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color(0.8f, 0.5f, 0.2f, 1f);
            }

            row.transform.SetParent(ScrollView.transform, false);
        }

        for (int i = 3; i < leaderboard.Count; i++)
        {
            string nickname = (string)leaderboard[i]["nickname"];
            int score = Convert.ToInt32(leaderboard[i]["score"]);
            int kills = Convert.ToInt32(leaderboard[i]["kills"]);
            int time = Convert.ToInt32(leaderboard[i]["time"]);
            int distance = Convert.ToInt32(leaderboard[i]["distance"]);
            int books = Convert.ToInt32(leaderboard[i]["books"]);

            GameObject row = Instantiate(leaderboard_row, ScrollView.transform.position, transform.rotation);
            row.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = nickname;
            row.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = score.ToString();
            row.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = kills.ToString();
            row.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = time.ToString();
            row.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = distance.ToString();
            row.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = books.ToString();

            row.transform.GetChild(7).GetComponent<TextMeshProUGUI>().text = "¹" + (i + 1).ToString();

            row.transform.SetParent(ScrollView.transform, false);
        }
    }

}
