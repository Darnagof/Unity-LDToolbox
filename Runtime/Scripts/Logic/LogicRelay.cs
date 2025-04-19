using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

namespace LDToolbox
{
    public class LogicRelay : MonoBehaviour
    {
        public UnityEvent Triggered;
        [Tooltip("Not enabled: no trigger and no calls count increment")]
        public bool relayEnabled = true;
        [Tooltip("Disable relay when triggered")]
        public bool triggerOnce = false;
        [Tooltip("Number of times to calls this relay to trigger it")]
        public int callsRequiredToTrigger = 1;
        [Tooltip("Reset number of calls to 0 when triggered")]
        public bool resetCallsOnTrigger = false;

        private int calls = 0;

        public void Trigger()
        {
            if (!relayEnabled) return;

            calls++;
            if (calls < callsRequiredToTrigger) return;

            // Trigger
            Triggered.Invoke();
            if (resetCallsOnTrigger) ResetCalls();
            if (triggerOnce) relayEnabled = false;
        }

        public void ResetCalls()
        {
            calls = 0;
        }

        public void setEnabled(bool status)
        {
            relayEnabled = status;
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            for (int i = 0; i < Triggered.GetPersistentEventCount(); i++)
            {
                Object targetObj = Triggered.GetPersistentTarget(i);
                if (targetObj is Component component)
                {
                    Gizmos.DrawLine(transform.position, component.transform.position);
                }
                else if (targetObj is GameObject go)
                {
                    Gizmos.DrawLine(transform.position, go.transform.position);
                }
            }

        }
#endif
    }
}
