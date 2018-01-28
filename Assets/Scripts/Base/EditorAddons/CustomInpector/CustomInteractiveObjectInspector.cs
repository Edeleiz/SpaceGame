#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
 
//[CustomEditor(typeof(InteractiveObject))]
public class CustomInteractiveObjectInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // Take out this if statement to set the value using setter when ever you change it in the inspector.
        // But then it gets called a couple of times when ever inspector updates
        // By having a button, you can control when the value goes through the setter and getter, your self.
        //if (false)//GUILayout.Button("Use setters/getters"))
        //{ 
        //    if (false)//target.GetType() == typeof(InteractiveObject))
        //   {
        //        InteractiveObject interactiveObject = (InteractiveObject)target;
        //       interactiveObject.actionProperty = interactiveObject.action;
        //    }
        //}
    }
}
#endif
