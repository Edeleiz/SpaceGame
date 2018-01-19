using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Inspectors
{
    [CustomEditor(typeof(InventoryObject))]
    public class InventoryInspector : Editor
    {
        private Dictionary<BaseItem, int> itemsDictionary;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var inventory = (InventoryObject)target;
            itemsDictionary = inventory.items;
            
            var rnd = 6;
            var reservedRect = GUILayoutUtility.GetRect(400, 300);//.Button(buttonRect, rnd.ToString() + " num");
            var buttonRect = new Rect(reservedRect);
            buttonRect.height = 30;
            buttonRect.width = 100;

            for (var i = 0; i < rnd; i++)
            {
                GUI.Button(buttonRect, rnd + " num");
                buttonRect.y += 50;
            }
        }

        private void DrawProperty(Rect rect, BaseItem property, int count = 1)
        {
            var countRect = new Rect(rect);
            countRect.x += rect.width + 20;
            itemsDictionary[(BaseItem)EditorGUI.ObjectField(rect, property, typeof(BaseItem), true)] = int.Parse(GUI.TextField(rect, count.ToString(), 10));
        }
    }
}
