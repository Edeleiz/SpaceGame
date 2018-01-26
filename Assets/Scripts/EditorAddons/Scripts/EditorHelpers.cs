using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EditorHelpers
{
    [MenuItem("GameObject/Set All Objects Dirty", false, 0)]
    public static void SetAllScenesDirty()
    {
        UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
    }

    [MenuItem("GameObject/Call Debug Method", false, 0)]
    public static void CallDebugMethod()
    {
        if (Selection.gameObjects.Length > 0)
        {
            var gameObject = Selection.gameObjects[0];

            var components = gameObject.GetComponents<Component>();

            foreach (var comp in components)
            {
                var type = comp.GetType();
                var prop = type.GetMethod("DebugMethod");

                if (prop != null)
                    prop.Invoke(comp, null);
            }
        }
    }
}
