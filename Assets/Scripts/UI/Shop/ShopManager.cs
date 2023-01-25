using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Canvas canvas;

    [Header("Shop Manager")]
    public Image shop;

    public TextMeshProUGUI[] cost = new TextMeshProUGUI[4];
    public CoinsManager coinsManager;

    [Header("To Upgrade")]
    public Hero hero;
    public Book book;

    public void DeactivateShop()
    {
        canvas.gameObject.SetActive(false);
        shop.gameObject.SetActive(false);
    }
    public void ActivateShop()
    {
        coinsManager.UpdateCoins();

        canvas.gameObject.SetActive(true);
        shop.gameObject.SetActive(true);

        coinsManager.UpdateCoins();
    }

    public void OnClickButtonBuy(string pick)
    {
        pick = pick.ToLower();

        if (pick == "damage")
        {
            UpdateCost(0);
            book.damage += book.damage / 5;
        }
        else if(pick == "health")
        {
            UpdateCost(1);
            hero.healhPoint += hero.healhPoint / 5;
        }
        else if(pick == "speed")
        {
            UpdateCost(2);
            hero.speed += hero.speed / 5;
        }
        else if(pick == "jump")
        {
            UpdateCost(3);
            hero.jumpForce += hero.jumpForce / 5;
        }

        coinsManager.UpdateCoins();
    }

    private void UpdateCost(int ID)
    {
        int money = Int32.Parse(cost[ID].text);
        int diff = hero.coins - money;
        if (diff >= 0)
        {
            hero.coins = diff;
            cost[ID].text = (money + 10).ToString();
        }
    }



    void Start()
    {
        DeactivateShop();
    }
}
