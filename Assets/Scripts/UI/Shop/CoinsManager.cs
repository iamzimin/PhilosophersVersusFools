using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    public Hero hero;
    public TextMeshProUGUI[] coins = new TextMeshProUGUI[7]; //fixme мб можно сделать одно поле для всех монет???
    
    public void UpdateCoins()
    {
        for (int i = 0; i < coins.Length; i++)
            coins[i].text = hero.coins.ToString();
    }

    public void AddCoinsToPlayer(int reward)
    {
        hero.coins += reward;
    }
    
}
