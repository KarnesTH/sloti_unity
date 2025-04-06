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


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            moneyLabel.text = $"${moneyValue}";

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
