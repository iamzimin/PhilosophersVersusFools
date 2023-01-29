using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Canvas canvas;
    public PauseGame pauseGame;

    [Header("Shop Manager")]
    public Image shop;

    public TextMeshProUGUI[] cost = new TextMeshProUGUI[5];
    public CoinsManager coinsManager;

    [Header("To Upgrade")]
    public Hero hero;
    public Book book;
    public Weapon weapon;

    public void DeactivateShop()
    {
        pauseGame.ResumeGame();

        shop.gameObject.SetActive(false);
    }
    public void ActivateShop()
    {
        pauseGame.StopGame();

        coinsManager.UpdateCoins();
        
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
            hero.maxHealhPoint += (hero.maxHealhPoint / 100) * 5;
            hero.healhPoint = hero.maxHealhPoint;

            float health = ((float)hero.healhPoint / (float)hero.maxHealhPoint) * 100;
            hero.healthText.text = hero.healthString + (Math.Round(health, 0)).ToString() + "%";
        }
        else if(pick == "speed")
        {
            UpdateCost(2);
            hero.speed += (hero.speed / 100) * 5;
        }
        else if(pick == "jump")
        {
            UpdateCost(3);
            hero.jumpForce += (hero.jumpForce / 100) * 5;
        }
        else if(pick == "delay")
        {
            UpdateCost(4);
            weapon.throwCooldown -= (weapon.throwCooldown / 100) * 50;
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
