using UnityEngine;
using UnityEngine.UI;

namespace KarnesDevelopment
{
    public class Slot : MonoBehaviour
    {
        public Image slotImage;

        void Start()
        {
            slotImage = GetComponent<Image>();
        }
    }
}
