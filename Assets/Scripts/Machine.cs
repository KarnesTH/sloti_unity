using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KarnesDevelopment
{
    public class Machine : MonoBehaviour
    {
        public GameObject leverContainer;

        private Animator m_animator;
        public InputAction leverPullAction;

        void Awake()
        {
            m_animator = leverContainer.GetComponent<Animator>();
            if (m_animator == null)
            {
                Debug.LogError("Animator component not found on leverContainer.");
            }
            leverPullAction.performed += OnLeverPull;
        }

        // Update is called once per frame
        void Update()
        {
         
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
            if (context.performed)
            {
                m_animator.SetTrigger("PullLever");
            }
        }
    }
}
