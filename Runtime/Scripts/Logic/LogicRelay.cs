using UnityEngine;
using UnityEngine.Events;

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

            foreach (GameObject target in GizmoUtils.GetGameObjectsListeningToEvent(Triggered))
            {
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
#endif
    }
}
