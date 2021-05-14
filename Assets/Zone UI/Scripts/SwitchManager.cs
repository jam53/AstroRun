using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Zone
{
    public class SwitchManager : MonoBehaviour
    {
        [Header("SWITCH")]
        public bool isOn;
        private Animator switchAnimator;

        [Header("EVENT")]
        public UnityEvent onEvent;
        public UnityEvent offEvent;

        string onTransition = "Switch On";
        string offTransition = "Switch Off";

        void Start()
        {
            switchAnimator = gameObject.GetComponent<Animator>();
            switchAnimator.Play(offTransition);

            if (isOn == true)
            {
                switchAnimator.Play(onTransition);
                onEvent.Invoke();
            }

            else
            {
                switchAnimator.Play(offTransition);
                offEvent.Invoke();
            }
        }

        public void AnimateSwitch()
        {
            Debug.Log(gameObject.transform.parent.name);
            if (isOn == true)
            {
                switchAnimator.Play(offTransition);
                offEvent.Invoke();
                isOn = false;
            }

            else
            {
                switchAnimator.Play(onTransition);
                onEvent.Invoke();
                isOn = true;
            }
        }
    }
}