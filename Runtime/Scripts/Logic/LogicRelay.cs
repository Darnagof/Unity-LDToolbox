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
            // TODO not working, fix this
            if (Selection.activeGameObject != gameObject) return;

            Gizmos.color = Color.green;
            for (int i = 0; i < Triggered.GetPersistentEventCount(); i++)
            {
                MonoBehaviour targetObj = Triggered.GetPersistentTarget(i) as MonoBehaviour;
                if (!targetObj) continue;
                Gizmos.DrawLine(transform.position, targetObj.transform.position);
            }
        }
#endif
    }
}
