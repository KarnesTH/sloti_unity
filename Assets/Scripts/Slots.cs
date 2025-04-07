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

        private GameManager gameManager;
        private int m_finishedSpins = 0;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            for (int i = 0; i <= slots.Length - 1; i++)
            {
                int randomIndex = Random.Range(0, slotsImages.Length - 1);

                slots[i].GetComponentsInChildren<Slot>()[0].slotImage.sprite = slotsImages[randomIndex];
            }
        }

        public void Spin()
        {
            m_finishedSpins = 0;
            for (int i = 0; i <= slots.Length - 1; i++)
            {
                StartCoroutine(SpinSlot(slots[i]));
            }
        }

        private IEnumerator SpinSlot(GameObject slot)
        {
            for (int i = 0; i < spinsPerTile; i++)
            {
                int randomIndex = Random.Range(0, slotsImages.Length - 1);
                slot.GetComponentsInChildren<Slot>()[0].slotImage.sprite = slotsImages[randomIndex];
                yield return new WaitForSeconds(delayBetweenSpins);
            }
            m_finishedSpins++;
        }
    }
}
