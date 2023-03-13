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
        public string name;
        public int score;
        public int kills;

        public Player(string name, int score, int kills)
        {
            this.name = name;
            this.score = score;
            this.kills = kills;
        }
    }

    //private string userID;
    private DatabaseReference databaseReference;
    public List<Dictionary<string, object>> leaderboard;
    public LeaderboardManager leaderboardManager;

    void Awake()
    {
        //userID = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        //GetDataFromFirebase();
        /*AddPlayer("123", 456, 678);
        AddPlayer("12533", 45346, 6345348);
        AddPlayer("1", 4, 6);*/
        //StartCoroutine(GetDataFromFirebase());
    }

    public void AddPlayer(string nickname, int score, int kills)
    {
        Player newPlayer = new Player(nickname, score, kills);
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
