using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Canvas canvas;

    [Header("ShopManager")]
    public Hero hero;
    public PlayerMovement player; //fixme

    public Image shop;

    public TextMeshProUGUI[] cost = new TextMeshProUGUI[4];
    public TextMeshProUGUI coins;

    public void DeactivateShop()
    {
        canvas.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
    }
    public void ActivateShop()
    {
        canvas.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);

        UpdateCoins();
    }

    public void OnClickButtonBuy(string pick)
    {
        pick = pick.ToLower();

        if (pick == "damage")
        {
            DeleteCoins(0);
        }
        else if(pick == "health")
        {
            DeleteCoins(1);
        }
        else if(pick == "speed")
        {
            DeleteCoins(2);
        }
        else if(pick == "jump")
        {
            DeleteCoins(3);
        }

        UpdateCoins();
    }

    private void DeleteCoins(int ID)
    {
        int money = Int32.Parse(cost[ID].text);
        int diff = hero.coins - money;
        if (diff >= 0)
        {
            hero.coins = diff;
            cost[ID].text = (money + 10).ToString();
        }
    }

    public void UpdateCoins()
    {
        coins.text = hero.coins.ToString();
    }



    void Start()
    {
        DeactivateShop();
    }
}
