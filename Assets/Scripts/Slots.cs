using System.Collections;
using UnityEngine;

namespace KarnesDevelopment
{
    public class Slots : MonoBehaviour
    {
        [Header("Slots Variables")]
        public GameObject[] slots;
        public Sprite[] slotsImages;

        [Header("Spin Settings")]
        public int spinsPerTile = 10;
        public float delayBetweenSpins = 0.2f;
        public float spinSpeed = 0.05f;

        private GameManager m_gameManager;
        private int m_finishedSpins = 0;

        /// <summary>
        /// Start is called once before the first execution of Update after the MonoBehaviour is created
        /// </summary>
        void Start()
        {
            m_gameManager = FindFirstObjectByType<GameManager>();
            for (int i = 0; i < slots.Length; i++)
            {
                int randomIndex = Random.Range(0, slotsImages.Length);

                slots[i].GetComponentsInChildren<Slot>()[0].slotImage.sprite = slotsImages[randomIndex];
            }
        }

        /// <summary>
        ///  Starts the spin of the slots.
        /// </summary>
        public void Spin()
        {
            m_finishedSpins = 0;
            for (int i = 0; i < slots.Length; i++)
            {
                StartCoroutine(SpinSlot(slots[i]));

            }
        }

        /// <summary>
        /// Spins a single slot.
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        private IEnumerator SpinSlot(GameObject slot)
        {
            for (int i = 0; i < spinsPerTile; i++)
            {
                int randomIndex = Random.Range(0, slotsImages.Length);
                slot.GetComponentsInChildren<Slot>()[0].slotImage.sprite = slotsImages[randomIndex];
                yield return new WaitForSeconds(delayBetweenSpins);
            }
            m_finishedSpins++;

            if (m_finishedSpins == slots.Length)
            {
                m_gameManager.CheckWin();
            }
        }

        /// <summary>
        /// Gets the image name of the slot.
        /// </summary>
        /// <param name="slot"></param>
        /// <returns>String of the image Name</returns>
        private string GetSlotImage(GameObject slot)
        {
            string result = slot.GetComponentsInChildren<Slot>()[0].slotImage.sprite.name;

            switch (result)
            {
                case "slot-symbol1_0":
                    result = "SEVEN";
                    break;
                case "slot-symbol2_0":
                    result = "CHERRY";
                    break;
                case "slot-symbol3_0":
                    result = "BELL";
                    break;
                case "slot-symbol4_0":
                    result = "BAR";
                    break;
                default:
                    result = "UNKNOWN";
                    break;
            }

            return result;
        }

        /// <summary>
        /// Checks if the slots match.
        /// </summary>
        /// <returns>String based on Symbolname</returns>
        public string CheckMatch()
        {
            string result = "";
            if (m_finishedSpins == slots.Length)
            {
                if (slots[0].GetComponentsInChildren<Slot>()[0].slotImage.sprite == slots[1].GetComponentsInChildren<Slot>()[0].slotImage.sprite &&
                    slots[0].GetComponentsInChildren<Slot>()[0].slotImage.sprite == slots[2].GetComponentsInChildren<Slot>()[0].slotImage.sprite)
                {
                    result = GetSlotImage(slots[0]);
                }
            }
            return result;
        }
    }
}
