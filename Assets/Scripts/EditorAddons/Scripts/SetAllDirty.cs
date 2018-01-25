using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SetAllDirty
{
    [MenuItem("GameObject/Set All Objects Dirty", false, 0)]
    public static void SetAllScenesDirty()
    {
        UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
    }
}
