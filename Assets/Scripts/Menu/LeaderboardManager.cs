using System;
using System.Collections;
using System.Collections.Generic;
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
            //row.transform.SetParent(ScrollView.transform, false);
        }
    }

}
