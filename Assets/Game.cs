using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System;
using System.Collections;
using DefaultNamespace;

public class Game : MonoBehaviour
{
    //CLICKER
    public TMP_Text scoreText;
    public float currentScore = 0;
    public float hitPower = 1;
    public float scoreIncreasedPerSecond = 1;
    public float x = 0f;

    //SHOP
    [FormerlySerializedAs("shop1prize")] public float shop1Prize = 25;
    [FormerlySerializedAs("shop1text")] public TMP_Text shop1Text;

    [FormerlySerializedAs("shop2prize")] public float shop2Prize = 125;
    [FormerlySerializedAs("shop2text")] public TMP_Text shop2Text;

    //AMOUNT
    public TMP_Text amount1Text;
    public int amount1 = 0;
    public float amount1Profit = 1;

    public TMP_Text amount2Text;
    public int amount2 = 0;
    public float amount2Profit = 5;

    //UPGRADE
    public float upgradePrize;
    public TMP_Text upgradeText;

    //ALL UPGRADE 
    public float allUpgradePrize = 500;
    public TMP_Text allUpgradeText;

    //ACHIEVEMENT
    public bool achievementScore;

    [FormerlySerializedAs("AchievementShope")]
    public bool achievementShope;

    public Image image1;
    public Image image2;

    //LEVEL SYSTEM
    public int level;
    public int exp;
    public int expToNextLevel;
    public TMP_Text levelText;

    //HIGHEST SCORE
    public int bestScore;
    public TMP_Text bestScoreText;

    //BUTTONS CHANGE
    public Sprite sp1, sp2, sp3, sp4;
    public Image clickerButton;

    public TMP_Text tx1, tx2, tx3, tx4;

    public int changeCost = 50;
    public int currentButton = 1;

    void Start()
    {
        StartCoroutine(SaveManagerTimer());
    }

    private IEnumerator SaveManagerTimer()
    {
        var saveData = new SaveManager();
        //This is a coroutine
        saveData.SaveData();
       
        yield return 5;    //Wait one frame
   
        saveData.LoadData();
    }

    public void Update()
    {
        // ToDo Сделать Сохранение по таймеру
        SaveManagerTimer();
        
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

        //ALL UPGRADE BUTTON
        allUpgradeText.text = "Удвоить пассив: " + Math.Floor(allUpgradePrize) + "$";
        
        //UPGRADE
        upgradeText.text = "Удвоить силу клика: " + Math.Floor(upgradePrize) + " $";

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

        //HIGHEST SCORE
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
        
        // ToDo Сделать так, чтобы 50 баксов не списывались постоянно
        Button1();
        Button2();
        Button3();
        Button4();
        for (int i = 0; i < 5; i++)
        {
            
        }
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
        ShopDispetcher(ref shop1Prize, ref amount1, ref amount1Profit, 1);
    }

    public void Shop2()
    {
        ShopDispetcher(ref shop2Prize, ref amount2, ref amount2Profit, 5);
    }

    private void ShopDispetcher(ref float shopPrize, ref int amount, ref float amountProfit, float xValue)
    {
        if (!(currentScore >= shopPrize)) return;
        currentScore -= shopPrize;
        amount++;
        amountProfit += xValue;
        x += xValue;
        shopPrize *= 2.2f;
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
        ButtonManager(ref changeCost, ref currentButton);
    }

    public void Button2()
    {
        ButtonManager(ref changeCost, ref currentButton);
    }

    public void Button3()
    {
        ButtonManager(ref changeCost, ref currentButton);
    }

    public void Button4()
    {
        ButtonManager(ref changeCost, ref currentButton);
    }

    private void ButtonManager(ref int changeCost, ref int currentButton)
    {
        if (!(currentScore >= changeCost)) return;
        currentScore -= changeCost;

        clickerButton.sprite = currentButton switch
        {
            1 => sp1,
            2 => sp2,
            3 => sp3,
            4 => sp4,
            _ => clickerButton.sprite
        };
    }
}