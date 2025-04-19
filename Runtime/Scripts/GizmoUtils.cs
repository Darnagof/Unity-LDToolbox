using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LDToolbox
{
    static public class GizmoUtils
    {
        static public List<GameObject> GetGameObjectsListeningToEvent(UnityEventBase evt)
        {
            List<GameObject> objects = new List<GameObject>();

            for (int i = 0; i < evt.GetPersistentEventCount(); i++)
            {
                Object targetObj = evt.GetPersistentTarget(i);
                if (targetObj is Component component)
                {
                    objects.Add(component.gameObject);
                }
                else if (targetObj is GameObject go)
                {
                    objects.Add(go);
                }
            }

            return objects;
        }
    }
}
