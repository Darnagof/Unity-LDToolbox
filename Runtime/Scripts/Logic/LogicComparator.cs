using UnityEngine;
using UnityEngine.Events;

namespace LDToolbox
{
    [System.Serializable]
    public class LogicComparatorEvent : UnityEvent<float> { }

    public class LogicComparator : MonoBehaviour
    {
        [Tooltip("Fired when the input value is less than the compare value. Sends the input value as data.")]
        public LogicComparatorEvent OnLessThan;
        public LogicComparatorEvent OnGreaterThan;
        public LogicComparatorEvent OnEqualTo;
        public LogicComparatorEvent OnNotEqualTo;

        [Tooltip("The value to compare against")]
        public float value = 0f;

        public void SetValue(float newValue)
        {
            value = newValue;
        }

        public void CompareWith(float inputValue)
        {
            float compResult = value - inputValue;
            if (compResult == 0f)
            {
                OnEqualTo.Invoke(inputValue);
                return;
            }
            OnNotEqualTo.Invoke(inputValue);

            if (compResult > 0f)
            {
                OnLessThan.Invoke(inputValue);
            }
            else
            {
                OnGreaterThan.Invoke(inputValue);
            }
        }
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            foreach (LogicComparatorEvent evt in new[] { OnLessThan, OnGreaterThan, OnEqualTo, OnNotEqualTo })
            {
                foreach (GameObject target in GizmoUtils.GetGameObjectsListeningToEvent(evt))
                {
                    Gizmos.DrawLine(transform.position, target.transform.position);
                }
            }
        }
#endif
    }
}
