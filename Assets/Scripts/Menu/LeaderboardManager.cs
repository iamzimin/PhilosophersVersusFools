using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class LeaderboardManager : MonoBehaviour
{
    public FirebaseDatabaseManager databaseManager;
    public List<Dictionary<string, object>> leaderboard;
    public GameObject leaderboard_row;
    public GameObject ScrollView;

    void Start()
    {
        databaseManager.StartCoroutine(databaseManager.GetDataFromFirebase());
        //this.leaderboard = databaseManager.leaderboard;
    }

    public void FillScrolView()
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            string name = (string)leaderboard[i]["name"];
            int score = Convert.ToInt32(leaderboard[i]["score"]);
            int kills = Convert.ToInt32(leaderboard[i]["kills"]);

            GameObject row = Instantiate(leaderboard_row, ScrollView.transform.position, transform.rotation);
            row.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
            row.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = score.ToString();
            row.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = kills.ToString();

            row.transform.SetParent(ScrollView.transform, false);
        }
    }

}
