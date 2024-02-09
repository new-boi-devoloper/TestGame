using PojectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonManager
    {
        //BUTTONS CHANGE
        public Sprite sp1, sp2, sp3, sp4;
        public Image clickerButton;

        public TMP_Text tx1, tx2, tx3, tx4;

        public int changeCost = 50;
        public int currentButton = 1;

        public void Update()
        {
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
        public void Button1()
        {
            ButtonDispatcher(1);
        }

        public void Button2()
        {
            ButtonDispatcher(2);
        }

        public void Button3()
        {
            ButtonDispatcher(3);
        }

        public void Button4()
        {
            ButtonDispatcher(4);
        }

        private void ButtonDispatcher(int buttonNumber)
        {
            var main = new Game();
            
            var costMultiplier = buttonNumber;
            
            if (main.currentScore >= changeCost * costMultiplier)
            {
                main.currentScore -= changeCost * costMultiplier;
                currentButton = buttonNumber;
            }
        }
    }
}