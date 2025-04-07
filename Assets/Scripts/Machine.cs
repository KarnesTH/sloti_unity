using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarnesDevelopment
{
    public class Machine : MonoBehaviour
    {
        public GameObject leverContainer;
        public Slots slots;

        private Animator m_animator;
        public InputAction leverPullAction;
        private bool m_isLeverActive = false;
        private GameManager m_gameManager;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            m_animator = leverContainer.GetComponent<Animator>();
            if (m_animator == null)
            {
                Debug.LogError("Animator component not found on leverContainer.");
            }
            m_gameManager = FindFirstObjectByType<GameManager>();
            leverPullAction.performed += OnLeverPull;
        }

        /// <summary>
        /// Enabling the leverPullAction when the script is enabled.
        /// </summary>
        private void OnEnable()
        {
            leverPullAction.Enable();
        }

        /// <summary>
        /// Disabling the leverPullAction when the script is disabled.
        /// </summary>
        private void OnDisable()
        {
            leverPullAction.Disable();
        }

        /// <summary>
        /// Called when the lever is pulled.
        /// </summary>
        /// <param name="context"></param>
        private void OnLeverPull(InputAction.CallbackContext context)
        {
            if (context.performed && !m_isLeverActive)
            {
                StartCoroutine(LeverPullSequence());
            }
        }

        /// <summary>
        /// Coroutine that handles the lever pull sequence.
        /// </summary>
        /// <returns></returns>
        private IEnumerator LeverPullSequence()
        {
            m_isLeverActive = true;
            m_animator.SetTrigger("PullLever");
            m_gameManager.gameLabel.text = "";

            yield return new WaitUntil(() => m_animator.GetCurrentAnimatorStateInfo(0).IsName("Lever"));

            float animationTime = m_animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationTime);

            int currMoney = Int32.Parse(m_gameManager.moneyLabel.text.Replace("$", ""));
            int bet = Int32.Parse(m_gameManager.betValue.text);
            if (currMoney >= bet)
            {
                currMoney -= bet;
                m_gameManager.moneyLabel.text = $"${currMoney}";
            }
            else
            {
                m_gameManager.gameLabel.text = "Not enough money!";
                yield break;
            }
            slots.Spin();

            yield return new WaitForSeconds(0.5f);

            m_isLeverActive = false;
        }
    }
}
