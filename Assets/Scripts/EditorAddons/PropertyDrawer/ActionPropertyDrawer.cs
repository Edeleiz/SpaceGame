using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

[CustomPropertyDrawer(typeof(ActionProperty))]
public class ActionPropertyDrawer : PropertyDrawer
{
    private ActionProperty _actionProperty;
    private BaseAction _action;
    private object _options;

    private bool _foldout = false;
    private Dictionary<string, System.Type> _optionsDict = new Dictionary<string, Type>();
    private Dictionary<string, object> _optionValues = new Dictionary<string, object>();

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        CheckInitialize(property, label);
        var totalHeight = 17.0f;
        if (_options != null)
            totalHeight += 17.0f;
        if (_foldout)
            totalHeight += (_optionsDict.Count) * 17f;
        return totalHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.DrawRect(position, new Color(0.6f, 0.6f, 0.6f));
        EditorGUI.BeginChangeCheck();
        var actionPos = position;
        actionPos.height = 17;
        var action = (BaseAction)EditorGUI.ObjectField(actionPos, "Action", _actionProperty.action, typeof(BaseAction), true);
        if (EditorGUI.EndChangeCheck())
        {
            _action = action;
            if (!_action)
                return;

            _options = _action.GetOptions();

            _actionProperty.action = _action;
            _actionProperty.options = (ActionOptions)_options;

            CheckOptions();
        }
        else if (_options != null)
        {
            position.y += 17;
            var foldoutRect = position;
            foldoutRect.width -= 2 * 18.0f;
            foldoutRect.height = 17.0f;

            _foldout = EditorGUI.Foldout(foldoutRect, _foldout, new GUIContent("Options"), true);
            EditorPrefs.SetBool("Options", _foldout);
            position.y += 17;

            if (_foldout)
                FillOptions(position);
        }
    }

    private void FillOptions(Rect position)
    {
        var fieldRect = position;
        fieldRect.height = 17.0f;

        foreach (var pair in _optionsDict)
        {
            EditorGUI.BeginChangeCheck();
            var newVal = DoField(fieldRect, pair.Key, pair.Value, _optionValues[pair.Key]);
            if (EditorGUI.EndChangeCheck())
            {

            }
            fieldRect.y += 17.0f;
        }
    }

    private static T DoField<T>(Rect rect, string label, Type type, T value)
    {
        Func<Rect, string, object, object> field;
        if (InspectorUtil.fieldsWithLabel.TryGetValue(type, out field))
            return (T)field(rect, label, value);

        if (type.IsEnum)
            return (T)(object)EditorGUI.EnumPopup(rect, new GUIContent(label), (Enum)(object)value);

        if (typeof(UnityEngine.Object).IsAssignableFrom(type))
            return (T)(object)EditorGUI.ObjectField(rect, new GUIContent(label), (UnityEngine.Object)(object)value, type, true);

        Debug.Log("Type is not supported: " + type);
        return value;
    }

    private void CheckOptions()
    {
        if (_options == null)
        {
            _optionsDict.Clear();
            return;
        }

        foreach (var field in _options.GetType().GetFields(BindingFlags.Instance |
                                                 BindingFlags.NonPublic |
                                                 BindingFlags.Public))
        {
            _optionsDict[field.Name] = field.FieldType;
            //Console.WriteLine("{0} = {1}", field.Name, field.GetValue(structValue));
        }
    }

    private void CheckInitialize(SerializedProperty property, GUIContent label)
    {
        if (_actionProperty == null)
        {
            var target = property.serializedObject.targetObject;
            _actionProperty = fieldInfo.GetValue(target) as ActionProperty;
            if (_actionProperty == null)
            {
                _actionProperty = new ActionProperty();
                fieldInfo.SetValue(target, _actionProperty);
            }
            _options = _actionProperty.options;
            _action = _actionProperty.action;

            CheckOptions();

            _foldout = EditorPrefs.GetBool("Options");
        }
        
        if (_actionProperty.options != null)
        {
            foreach (var field in _actionProperty.options.GetType().GetFields(BindingFlags.Instance |
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.Public))
            {
                _optionValues[field.Name] = field.GetValue(_actionProperty.options);
                //Console.WriteLine("{0} = {1}", field.Name, field.GetValue(structValue));
            }
        }
    }
}
