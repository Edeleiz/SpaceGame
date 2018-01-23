using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Inspectors
{
    //[CustomEditor(typeof(InventoryObject))]
    public class InventoryInspector : Editor
    {
        private static Dictionary<BaseItem, int> itemsToSave;
        private Dictionary<BaseItem, int> itemsDictionary = null;

        private static Rect buttonRect = new Rect(0, 0, 100, 17);

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (itemsToSave == null)
                itemsToSave = new Dictionary<BaseItem, int>();

            var inventory = (Inventory)target;
            //itemsDictionary = itemsDictionary ?? new Dictionary<BaseItem, int>(InventoryObject.GetInitialItems(inventory));
            
            var len = itemsDictionary.Count;
            var reservedRect = GUILayoutUtility.GetRect(400, len * 27 + 54);
            buttonRect.x = reservedRect.x;
            buttonRect.y = reservedRect.y;

            //if (GUI.Button(buttonRect, "Save items"))
                //InventoryObject.SetInitialItems(inventory, itemsToSave);
            buttonRect.y += 17 + 10;

            foreach (var itemPair in itemsDictionary)
            {
                DrawProperty(buttonRect, itemPair.Key, itemPair.Value);
                buttonRect.y += 17 + 10;
            }

            if (GUI.Button(buttonRect, "Add item"))
                itemsDictionary[ScriptableObject.CreateInstance<BaseItem>()] = 0;
        }

        private void DrawProperty(Rect rect, BaseItem property, int count = 1)
        {
            var countRect = new Rect(rect);
            countRect.x += rect.width + 20;
            itemsToSave[(BaseItem)EditorGUI.ObjectField(rect, property, typeof(BaseItem), true)] = int.Parse(GUI.TextField(countRect, count.ToString(), 10));
        }

        private void OnDestroy()
        {
            itemsToSave = null;
            Debug.Log("destriyed");
        }
    }
}
