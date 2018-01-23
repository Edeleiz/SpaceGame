using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class InspectorUtil
{
    public static readonly Dictionary<Type, Func<Rect, object, object>> fields =
        new Dictionary<Type, Func<Rect, object, object>>()
        {
            { typeof(int), (rect, value) => EditorGUI.IntField(rect, (int)value) },
            { typeof(float), (rect, value) => EditorGUI.FloatField(rect, (float)value) },
            { typeof(string), (rect, value) => EditorGUI.TextField(rect, (string)value) },
            { typeof(bool), (rect, value) => EditorGUI.Toggle(rect, (bool)value) },
            { typeof(Vector2), (rect, value) => EditorGUI.Vector2Field(rect, GUIContent.none, (Vector2)value) },
            { typeof(Vector3), (rect, value) => EditorGUI.Vector3Field(rect, GUIContent.none, (Vector3)value) },
            { typeof(Bounds), (rect, value) => EditorGUI.BoundsField(rect, (Bounds)value) },
            { typeof(Rect), (rect, value) => EditorGUI.RectField(rect, (Rect)value) },
        };

    public static readonly Dictionary<Type, Func<Rect, string, object, object>> fieldsWithLabel =
        new Dictionary<Type, Func<Rect, string, object, object>>()
        {
            { typeof(int), (rect, label, value) => EditorGUI.IntField(rect, new GUIContent(label), (int)value) },
            { typeof(float), (rect, label, value) => EditorGUI.FloatField(rect, new GUIContent(label), (float)value) },
            { typeof(string), (rect, label, value) => EditorGUI.TextField(rect, new GUIContent(label), (string)value) },
            { typeof(bool), (rect, label, value) => EditorGUI.Toggle(rect, new GUIContent(label), (bool)value) },
            { typeof(Vector2), (rect, label, value) => EditorGUI.Vector2Field(rect, new GUIContent(label), (Vector2)value) },
            { typeof(Vector3), (rect, label, value) => EditorGUI.Vector3Field(rect, new GUIContent(label), (Vector3)value) },
            { typeof(Bounds), (rect, label, value) => EditorGUI.BoundsField(rect, new GUIContent(label), (Bounds)value) },
            { typeof(Rect), (rect, label, value) => EditorGUI.RectField(rect, new GUIContent(label), (Rect)value) },
        };
}
