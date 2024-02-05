using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    //CLICKER
    public TMP_Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    //SHOP
    [FormerlySerializedAs("shop1prize")] public float shop1Prize;
    [FormerlySerializedAs("shop1text")] public TMP_Text shop1Text;

    [FormerlySerializedAs("shop2prize")] public float shop2Prize;
    [FormerlySerializedAs("shop2text")] public TMP_Text shop2Text;

    //AMOUNT
    public TMP_Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public TMP_Text amount2Text;
    public int amount2;
    public float amount2Profit;

    //UPGRADE
    public float upgradePrize;
    public TMP_Text upgradeText;

    //ALL UPGRADE 
    public float allUpgradePrize;
    public TMP_Text allUpgradeText;

    //ACHIEVEMENT
    public bool achievementScore;
    [FormerlySerializedAs("AchievementShope")] public bool achievementShope;

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
    public int currentButton = 1;

    // Start is called before the first frame update
    public void Start()
    {
        //CLICKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;
        //DEFAULT VARIABLES THAT WE NEED TO PRELOAD 
        shop1Prize = 25;
        shop2Prize = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;
        allUpgradePrize = 500;

        //LOAD
        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        x = PlayerPrefs.GetInt("x", 0);

        shop1Prize = PlayerPrefs.GetFloat("shop1Prize", 25);
        shop2Prize = PlayerPrefs.GetFloat("shop2Prize", 125);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetInt("amount1Profit", 0);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetInt("amount2Profit", 0);
        upgradePrize = PlayerPrefs.GetFloat("upgradePrize", 50);

        allUpgradePrize = PlayerPrefs.GetFloat("allUpgradePrize", 500);

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
        shop1Text.text = "Мелкий клик 1: " + Math.Floor(shop1Prize) + " $";
        shop2Text.text = "Среднестат клик 2: " + Math.Floor(shop2Prize) + " $";
        
        //AMOUNT OF BOUGHT PASSIVES
        amount1Text.text = "Мелкий клик 1: " + amount1 + " Мелкий бонус $: " + amount1Profit + "/s";
        amount2Text.text = "Средний клик 2: " + amount2 + " Средний бонус $: " + amount2Profit + "/s";

        //UPGRADE
        upgradeText.text = "Удвоить силу клика: " + Math.Floor(upgradePrize) + " $";

        //SAVE
        PlayerPrefs.SetInt("currentScore", (int)currentScore);
        PlayerPrefs.SetInt("hitPower", (int)hitPower);
        PlayerPrefs.SetInt("x", (int)x);

        PlayerPrefs.SetFloat("shop1Prize", shop1Prize);
        PlayerPrefs.SetFloat("shop2Prize", shop2Prize);
        PlayerPrefs.SetInt("amount1", amount1);
        PlayerPrefs.SetInt("amount1Profit", (int)amount1Profit);
        PlayerPrefs.SetInt("amount2", amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)amount2Profit);
        PlayerPrefs.SetFloat("upgradePrize", upgradePrize);

        PlayerPrefs.SetFloat("allUpgradePrize", allUpgradePrize);

        //ALL UPGRADE BUTTON
        allUpgradeText.text = "Удвоить пассив: " + Math.Floor(allUpgradePrize) + "$";

        //LEVEL SAVE
        PlayerPrefs.SetInt("bestScore", bestScore);

        //ACHIEVEMENT 
        if (currentScore >= 1000)
        {
            achievementScore = true;
        }

        if (amount2 >= 2)
        {
            achievementShope = true;
        }

        image1.color = achievementScore ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 1f, 1f, 1f);

        image2.color = achievementShope ? new Color(0f, 1f, 0f, 1f) : new Color(1f, 1f, 1f, 1f);

        //LEVEL
        if (exp >= expToNextLevel)
        {
            level++;
            exp = 0;
            expToNextLevel *= 2;
        }

        levelText.text = level + " уровень";

        //HIEGHEST SCORE
        if (currentScore > bestScore)
        {
            bestScore = (int)currentScore;
        }

        bestScoreText.text = bestScore + " Лучший счёт";

        //BUTTONS
        tx1.text = "Купить за: " + changeCost;
        tx2.text = "Купить за: " + changeCost * 2;
        tx3.text = "Купить за: " + changeCost * 3;
        tx4.text = "Купить за: " + changeCost * 4;

        clickerButton.sprite = currentButton switch
        {
            1 => sp1,
            2 => sp2,
            3 => sp3,
            4 => sp4,
            _ => clickerButton.sprite
        };
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
        if (currentScore >= shop1Prize)
        {
            currentScore -= shop1Prize;
            amount1++;
            amount1Profit++;
            x++;
            shop1Prize *= 2.2f;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2Prize)
        {
            currentScore -= shop2Prize;
            amount2++;
            amount2Profit += 5;
            x += 5;
            shop2Prize *= 2.2f;
        }
    }

    //UPGRADE
    public void Upgrade()
    {
        if (currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 2.2f;
        }
    }
    //NEW
    public void AllProfitsUpgrade()
    {
        if (currentScore >= allUpgradePrize)
        {
            currentScore -= allUpgradePrize;
            x *= 2;
            allUpgradePrize *= 3.3f;
            amount1Profit *= 2;
            amount2Profit *= 2;
        }
    }
    public void Button1()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost;
            currentButton = 1;
        }
    }
    public void Button2()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost * 2;
            currentButton = 2;
        }
    }
    public void Button3()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost * 3;
            currentButton = 3;
        }
    }
    public void Button4()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost * 4;
            currentButton = 4;
        }
    }

}