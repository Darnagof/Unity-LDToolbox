#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace LDToolbox
{
    public class Comment : MonoBehaviour
    {
        [Tooltip("Display comment in Scene View")]
        public bool showInScene = false;
        [TextArea(1, 10)]
        public string comment;

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void DrawGizmo(Comment comment, GizmoType gizmoType)
        {
            if (!comment.showInScene || string.IsNullOrWhiteSpace(comment.comment)) return;

            Handles.BeginGUI();

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.yellow;
            style.fontStyle = FontStyle.Italic;
            style.alignment = TextAnchor.UpperLeft;

            Handles.Label(comment.transform.position + Vector3.up * 0.25f, comment.comment, style);

            Handles.EndGUI();
        }
    }
}
#endif
