using UnityEngine;
using TMPro;

namespace KarnesDevelopment
{
    public class GameManager : MonoBehaviour
    {
        [Header("Money Variables")]
        public TextMeshProUGUI moneyLabel;
        public int moneyValue;
        [Header("Game Variables")]
        public TextMeshProUGUI gameLabel;
        [Header("Bet Variables")]
        public TextMeshProUGUI betValue;
        [Header("Bonus Variables")]
        public int bonusSevenValue;
        public int bonusCherryValue;
        public int bonusBellValue;
        public int bonusBarValue;
        public TextMeshProUGUI bonusSevenLbl;
        public TextMeshProUGUI bonusCherryLbl;
        public TextMeshProUGUI bonusBellLbl;
        public TextMeshProUGUI bonusBarLbl;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            moneyLabel.text = $"${moneyValue}";
            bonusSevenLbl.text = "JACKPOT";
            bonusCherryLbl.text = $"+ {bonusCherryValue}";
            bonusBellLbl.text = $"+ {bonusBellValue}";
            bonusBarLbl.text = $"+ {bonusBarValue}";
            gameLabel.text = "";

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CheckWin()
        {
            Debug.Log("CheckWin called");
        }
    }
}
