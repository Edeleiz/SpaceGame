#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public static class BreakPrefab
{
    private const string k_WARNING_MSG_HEADER = "Breaking prefab connection";
    private const string k_WARNING_MSG_TEXT = "This is dangerous and can lead to broken objects and broken links to this object because it will be destroyed and recreated. Are you sure?";
    private const string k_WARNING_MSG_POS_ANSWER = "I'm Sure";
    private const string k_WARNING_MSG_NEG_ANSWER = "Cancel";
    private const string k_UNDO_LOG_CREATED = "Created object to break prefab.";
    private const string k_UNDO_LOG_MOVED = "Move new object to scene";
    private const string k_UNDO_LOG_PARENTED = "Set correct parent";
    private const string k_WARNING_LOG_NOT_PREFAB = "Object: {0} is not a prefab and will be ignored.";

    [MenuItem("GameObject/Break Prefab Instance Completely", false, 0)]
    public static void BreakPrefabConnectionStrong()
    {
        List<GameObject> news = new List<GameObject>();

        if (Selection.gameObjects.Length > 0)
        {
            if (EditorUtility.DisplayDialog(k_WARNING_MSG_HEADER, k_WARNING_MSG_TEXT, k_WARNING_MSG_POS_ANSWER, k_WARNING_MSG_NEG_ANSWER))
            {
                while (Selection.gameObjects.Length > 0)
                {
                    GameObject old = Selection.gameObjects[0];

                    if (PrefabUtility.GetPrefabType(old) != PrefabType.None)
                    {
                        Scene oldScene = old.scene;
                        Transform oldParent = old.transform.parent;
                        Quaternion oldRot = old.transform.rotation;
                        Vector3 oldPos = old.transform.position;
                        string oldName = old.name;
                        int oldSiblingIndex = old.transform.GetSiblingIndex();

                        GameObject replacementObject = MonoBehaviour.Instantiate(old) as GameObject;
                        Undo.RegisterCreatedObjectUndo(replacementObject, k_UNDO_LOG_CREATED);
                        Undo.DestroyObjectImmediate(old);

                        if (replacementObject.scene != oldScene)
                        {
                            Undo.MoveGameObjectToScene(replacementObject, oldScene, k_UNDO_LOG_MOVED);
                        }

                        if (oldParent != null)
                        {
                            Undo.SetTransformParent(replacementObject.transform, oldParent, k_UNDO_LOG_PARENTED);
                        }

                        replacementObject.name = oldName;
                        replacementObject.transform.rotation = oldRot;
                        replacementObject.transform.position = oldPos;
                        replacementObject.transform.SetSiblingIndex(oldSiblingIndex);
                        news.Add(replacementObject);
                    }
                    else
                    {
                        Debug.LogWarning(string.Format(k_WARNING_LOG_NOT_PREFAB, old.name));
                    }
                }
                Selection.objects = news.ToArray();
            }
        }
    }
}

#endif