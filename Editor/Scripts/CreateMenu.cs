using UnityEngine;
using UnityEditor;

namespace LDToolbox
{
    public class CreateMenu
    {
        static void CreateGameObjectWithComponent<componentType>(string name, MenuCommand menuCommand) where componentType : Component
        {
            GameObject go = new GameObject(name);
            go.AddComponent<componentType>();
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create LogicRelay");
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Logic/Logic Relay", false, 10)]
        static void CreateLogicRelay(MenuCommand menuCommand)
        {
            CreateGameObjectWithComponent<LogicRelay>("LogicRelay", menuCommand);
        }

        [MenuItem("GameObject/Logic/Logic Comparator", false, 10)]
        static void CreateLogicComparator(MenuCommand menuCommand)
        {
            CreateGameObjectWithComponent<LogicComparator>("LogicComparator", menuCommand);
        }
    }
}
