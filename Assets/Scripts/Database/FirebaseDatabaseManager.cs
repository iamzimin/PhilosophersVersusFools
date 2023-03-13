using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class FirebaseDatabaseManager : MonoBehaviour
{
    public class Player
    {
        public string nickname;
        public int score;
        public int kills;
        public int time;
        public int distance;
        public int books;

        public Player(string nickname, int score, int kills, int time, int distance, int books)
        {
            this.nickname = nickname;
            this.score = score;
            this.kills = kills;
            this.time = time;
            this.distance = distance;
            this.books = books;
        }
    }

    //private string userID;
    private DatabaseReference databaseReference;
    public List<Dictionary<string, object>> leaderboard;
    public LeaderboardManager leaderboardManager;

    void Awake()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
/*
        AddPlayer("hello", 10, 15, 166, 544, 35);
        AddPlayer("world", 10, 145, 16, 544, 5);
        AddPlayer("its", 10, 165, 66, 544, 58);
        AddPlayer("game", 10, 415, 166, 44, 33);
        AddPlayer("for", 10, 15, 16, 54, 35);
        AddPlayer("univercity", 1, 15, 166, 544, 385);
        AddPlayer("hehehe", 10, 15, 146, 584, 3);
        AddPlayer("hahaha", 10, 25, 16, 44, 35);*/
    }

    public void AddPlayer(string nickname, int score, int kills, int time, int distance, int books)
    {
        Player newPlayer = new Player(nickname, score, kills, time, distance, books);
        string json = JsonUtility.ToJson(newPlayer);

        databaseReference.Child("leaderboard").Push().SetRawJsonValueAsync(json);
    }

    public IEnumerator GetDataFromFirebase()
    {
        /*
        FirebaseDatabase.DefaultInstance.GetReference("leaderboard").GetValueAsync().
    ContinueWithOnMainThread(task => {
        if (task.IsFaulted)
        {
            Debug.Log("Database GetValueAsync error");
            Debug.Log(task.Exception);
        }
        else if (task.IsCompleted)
        {
            snapshot = task.Result;
            Debug.Log(snapshot.Child("leaderboard").Value.ToString());
        }
        else
        {
        }
    });*/
        var data = databaseReference.Child("leaderboard").GetValueAsync();

        yield return new WaitUntil(predicate: () => data.IsCompleted);

        leaderboard = new List<Dictionary<string, object>>();
        if (data != null)
        {
            DataSnapshot snapshot = data.Result;
            foreach (DataSnapshot player in snapshot.Children)
            {
                Dictionary<string, object> player_data = (Dictionary<string, object>)player.GetValue(true);
                leaderboard.Add(player_data);

                /*
                string name = (string)player_data["name"];
                int score = Convert.ToInt32(player_data["score"]);
                int kills = Convert.ToInt32(player_data["kills"]);

                Debug.Log(name + " " + score.ToString() + " " + kills.ToString());*/
            }
        }
        if (leaderboardManager != null)
        {
            leaderboardManager.leaderboard = leaderboard;
            leaderboardManager.FillScrolView();
        }
    }

}
