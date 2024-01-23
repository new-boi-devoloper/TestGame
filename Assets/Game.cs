using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //CLICKER
    public TMP_Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    //SHOP
    public int shop1prize;
    public TMP_Text shop1text;

    public int shop2prize;
    public TMP_Text shop2text;

    //AMOUNT
    public TMP_Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public TMP_Text amount2Text;
    public int amount2;
    public float amount2Profit;

    //UPGRADE
    public int upgradePrize;
    public TMP_Text upgradeText;

    //NEW
    public int allUpgradePrize;
    public TMP_Text allUpgradeText;

    //ACHIEVEMENT
    public bool achievementScore;
    public bool AchievementShope;

    public Image image1;
    public Image image2;

    //LEVEL SYSTEM
    public int level;
    public int exp;
    public int expToNextLevel;
    public TMP_Text levelText;

    //HEIGHEST SCORE
    public int bestScore;
    public TMP_Text bestScoreText;

    //BUTTONS CHANGE
    public Sprite sp1, sp2, sp3, sp4;
    public Image clickerButton;

    public TMP_Text tx1, tx2, tx3, tx4;

    public int changeCost = 50;
    public int cuurentButton;

    // Start is called before the first frame update
    public void Start()
    {
        //CLICKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;
        //DEFAULT VRIABLES THAT WE NEED TO PRELOAD 
        shop1prize = 25;
        shop2prize = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;

        //RESET SAVE SYSTEM
        //PlayerPrefs.DeleteAll();

        //LOAD
        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        x = PlayerPrefs.GetInt("x", 0);

        shop1prize = PlayerPrefs.GetInt("shop1prize", 25);
        shop2prize = PlayerPrefs.GetInt("shop2prize", 125);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetInt("amount1Profit", 0);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetInt("amount2Profit", 0);
        upgradePrize = PlayerPrefs.GetInt("upgradePrize", 50);

        allUpgradePrize = 500;// POSSIBLE LATER TO ADD TO SAVE & LOAD SYSTEM

        //LEVEL LOAD
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
    }

    // Update is called once per frame
    public void Update()
    {
        //CLICKER
        scoreText.text = (int)currentScore + " $";
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore += scoreIncreasedPerSecond;

        //SHOP
        shop1text.text = "Мелкий клик 1: " + shop1prize + " $";
        shop2text.text = "Среднестат клик 2: " + shop2prize + " $";

        //AMOUNT OF BOUGHT PASSIVES
        amount1Text.text = "Мелкий клик 1: " + amount1 + " Мелкий бонус $: " + amount1Profit + "/s";
        amount2Text.text = "Средний клик 2: " + amount2 + " Средний бонус $: " + amount2Profit + "/s";

        //UPGRADE
        upgradeText.text = "Cost: " + upgradePrize + " $";

        //SAVE
        PlayerPrefs.SetInt("currentScore", (int)currentScore);
        PlayerPrefs.SetInt("hitPower", (int)hitPower);
        PlayerPrefs.SetInt("x", (int)x);

        PlayerPrefs.SetInt("shop1prize", (int)shop1prize);
        PlayerPrefs.SetInt("shop2prize", (int)shop2prize);
        PlayerPrefs.SetInt("amount1", (int)amount1);
        PlayerPrefs.SetInt("amount1Profit", (int)amount1Profit);
        PlayerPrefs.SetInt("amount2", (int)amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)amount2Profit);
        PlayerPrefs.SetInt("upgradePrize", (int)upgradePrize);

        allUpgradeText.text = "Увеличить весь пассив: " + allUpgradePrize + "$";

        //LEVEL SAVE
        PlayerPrefs.SetInt("bestScore", bestScore);

        //ACHIEVEMENT 
        if (currentScore >= 1000)
        {
            achievementScore = true;
        }

        if (amount2 >= 2)
        {
            AchievementShope = true;
        }

        image1.color = achievementScore == true ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 1f, 1f, 1f);

        image2.color = AchievementShope == true ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 1f, 1f, 1f);

        //LEVEL
        if(exp >= expToNextLevel)
        {
            level++;
            exp = 0;
            expToNextLevel *= 2;
        }

        levelText.text = level + "уровень";

        //HIEGHEST SCORE
        if(currentScore > bestScore)
        {
            bestScore = (int)currentScore;
        }

        bestScoreText.text = bestScore + " Лучший счёт";
    }


    public void Hit()
    {
        currentScore += hitPower;

        //EXP
        exp++;
    }

    //SHOP
    public void Shop1()
    {
        if (currentScore >= shop1prize)
        {
            currentScore -= shop1prize;
            amount1++;
            amount1Profit++;
            x++;
            shop1prize += 25;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2prize)
        {
            currentScore -= shop2prize;
            amount2++;
            amount2Profit += 5;
            x += 5;
            shop2prize += 50;
        }
    }

    //UPGRADE
    public void Upgrade()
    {
        if (currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 2;
        }
    }
    //NEW
    public void AllProfitsUpgrade()
    {
        if (currentScore >= allUpgradePrize)
        {
            currentScore -= allUpgradePrize;
            x *= 2;
            allUpgradePrize *= 3;
            amount1Profit *= 2;
            amount2Profit *= 2;
        }
    }
}