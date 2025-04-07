using UnityEngine;
using TMPro;
using System;

namespace KarnesDevelopment
{
    public class GameManager : MonoBehaviour
    {
        [Header("Money Settings")]
        public TextMeshProUGUI moneyLabel;
        public int moneyValue;
        [Header("Game Settings")]
        public TextMeshProUGUI gameLabel;
        [Header("Bet Settings")]
        public TextMeshProUGUI betValue;
        public int mulitiplierValue = 10;
        [Header("Bonus Settings")]
        public int bonusSevenValue;
        public int bonusCherryValue;
        public int bonusBellValue;
        public int bonusBarValue;
        public TextMeshProUGUI bonusSevenLbl;
        public TextMeshProUGUI bonusCherryLbl;
        public TextMeshProUGUI bonusBellLbl;
        public TextMeshProUGUI bonusBarLbl;

        private Slots m_slots;


        /// <summary>
        /// Start is called once before the first execution of Update after the MonoBehaviour is created
        /// </summary>
        void Start()
        {
            m_slots = FindFirstObjectByType<Slots>();
            moneyLabel.text = $"${moneyValue}";
            bonusSevenLbl.text = "JACKPOT";
            bonusCherryLbl.text = $"+ {bonusCherryValue}";
            bonusBellLbl.text = $"+ {bonusBellValue}";
            bonusBarLbl.text = $"+ {bonusBarValue}";
            gameLabel.text = "";

        }

        /// <summary>
        /// Checks the result of the spin and updates the money label accordingly.
        /// </summary>
        public void CheckWin()
        {
            int bet = Int32.Parse(betValue.text);
            int currMoney = Int32.Parse(moneyLabel.text.Replace("$", ""));
            int bonus = 0;
            string result = m_slots.CheckMatch();
            switch (result)
            {
                case "SEVEN":
                    bonus = bonusSevenValue + bet;
                    gameLabel.text = $"YOU WIN {bonus}";
                    currMoney += bonus;
                    moneyLabel.text = $"${currMoney}";
                    break;
                case "CHERRY":
                    bonus = bonusCherryValue + bet;
                    gameLabel.text = $"YOU WIN {bonus}";
                    currMoney += bonus;
                    moneyLabel.text = $"${currMoney}";
                    break;
                case "BELL":
                    bonus = bonusBellValue + bet;
                    gameLabel.text = $"YOU WIN {bonus}";
                    currMoney += bonus;
                    moneyLabel.text = $"${currMoney}";
                    break;
                case "BAR":
                    bonus = bonusBarValue + bet;
                    gameLabel.text = $"YOU WIN {bonus}";
                    currMoney += bonus;
                    moneyLabel.text = $"${currMoney}";
                    break;
                default:
                    gameLabel.text = "";
                    break;
            }
        }

        /// <summary>
        /// Increases the bet value by the multiplier value.
        /// </summary>
        public void IncreaseBet()
        {
            int bet = Int32.Parse(betValue.text);

            if (bet >= 50 && bet < 200)
            {
                bet += mulitiplierValue;
                betValue.text = $"{bet}";
            }
            else if (bet >= 200)
            {
                bet = 50;
                betValue.text = $"{bet}";
            }
        }

        /// <summary>
        /// Decreases the bet value by the multiplier value.
        /// </summary>
        public void DecreaseBet()
        {
            int bet = Int32.Parse(betValue.text);
            if (bet > 50 && bet <= 200)
            {
                bet -= mulitiplierValue;
                betValue.text = $"{bet}";
            }
            else if (bet <= 50)
            {
                bet = 200;
                betValue.text = $"{bet}";
            }
        }
    }
}
