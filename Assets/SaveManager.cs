using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Game gameInPut;

    public void SaveData()
    {
        //SAVE
        PlayerPrefs.SetInt("currentScore", (int)gameInPut.currentScore);
        PlayerPrefs.SetInt("hitPower", (int)gameInPut.hitPower);
        PlayerPrefs.SetInt("x", (int)gameInPut.x);

        PlayerPrefs.SetFloat("shop1Prize", gameInPut.shop1Prize);
        PlayerPrefs.SetFloat("shop2Prize", gameInPut.shop2Prize);
        PlayerPrefs.SetInt("amount1", gameInPut.amount1);
        PlayerPrefs.SetInt("amount1Profit", (int)gameInPut.amount1Profit);
        PlayerPrefs.SetInt("amount2", gameInPut.amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)gameInPut.amount2Profit);
        PlayerPrefs.SetFloat("upgradePrize", gameInPut.upgradePrize);

        PlayerPrefs.SetFloat("allUpgradePrize", gameInPut.allUpgradePrize);

        //ALL UPGRADE BUTTON
        gameInPut.allUpgradeText.text = "Удвоить пассив: " + Math.Floor(gameInPut.allUpgradePrize) + "$";

        //LEVEL SAVE
        PlayerPrefs.SetInt("bestScore", gameInPut.bestScore);
    }

    public void LoadData()
    {
        //LOAD
        gameInPut.currentScore = PlayerPrefs.GetInt("currentScore", 0);
        gameInPut.hitPower = PlayerPrefs.GetInt("hitPower", 1);
        gameInPut.x = PlayerPrefs.GetInt("x", 0);

        gameInPut.shop1Prize = PlayerPrefs.GetFloat("shop1Prize", 25);
        gameInPut.shop2Prize = PlayerPrefs.GetFloat("shop2Prize", 125);
        gameInPut.amount1 = PlayerPrefs.GetInt("amount1", 0);
        gameInPut.amount1Profit = PlayerPrefs.GetInt("amount1Profit", 1);
        gameInPut.amount2 = PlayerPrefs.GetInt("amount2", 0);
        gameInPut.amount2Profit = PlayerPrefs.GetInt("amount2Profit", 5);
        gameInPut.upgradePrize = PlayerPrefs.GetFloat("upgradePrize", 50);

        gameInPut.allUpgradePrize = PlayerPrefs.GetFloat("allUpgradePrize", 500);

        //LEVEL LOAD
        gameInPut.bestScore = PlayerPrefs.GetInt("bestScore", 0);
    }

    public void Start()
    {
        LoadData();
    }
}