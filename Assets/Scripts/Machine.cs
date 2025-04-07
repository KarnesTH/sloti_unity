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

        void Awake()
        {
            m_animator = leverContainer.GetComponent<Animator>();
            if (m_animator == null)
            {
                Debug.LogError("Animator component not found on leverContainer.");
            }
            leverPullAction.performed += OnLeverPull;
        }

        private void OnEnable()
        {
            leverPullAction.Enable();
        }

        private void OnDisable()
        {
            leverPullAction.Disable();
        }

        private void OnLeverPull(InputAction.CallbackContext context)
        {
            if (context.performed && !m_isLeverActive)
            {
                StartCoroutine(LeverPullSequence());
            }
        }

        private IEnumerator LeverPullSequence()
        {
            m_isLeverActive = true;
            m_animator.SetTrigger("PullLever");

            yield return new WaitUntil(() => m_animator.GetCurrentAnimatorStateInfo(0).IsName("Lever"));

            float animationTime = m_animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationTime);

            slots.Spin();

            yield return new WaitForSeconds(0.5f);

            m_isLeverActive = false;
        }
    }
}
