using UnityEngine;
using UnityEngine.UI;

namespace KarnesDevelopment
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage;

        /// <summary>
        /// Start is called once before the first execution of Update after the MonoBehaviour is created
        /// </summary>
        void Start()
        {
            slotImage = GetComponent<Image>();
        }
    }
}
