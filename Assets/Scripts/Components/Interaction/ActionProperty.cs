using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;
using System.ComponentModel;

[System.Serializable] public class ActionDicitonary : SerializableDictionary<string, string> { }
[System.Serializable] public class ActionGameObjectDicitonary : SerializableDictionary<string, GameObject> { }

[System.Serializable]
public class ActionProperty
{
    [SerializeField]
    private BaseAction _action = null;
    public BaseAction action
    {
        get { return _action;  }
        set
        {
            if (_action == value)
                return;

            if (_action)
                options = null;

            _action = value;
        }
    }

    [NonSerialized]
    private ActionOptions _options = null;
    public ActionOptions options
    {
        get
        {
            if ((_options == null || _options.GetType() == typeof(ActionOptions)) && action != null)
                _options = action.GetOptions();
            if (Application.isEditor)
                DeserializeOptions();
            return _options;
        }
        set
        {
            if (_options != null)
            {
                _serializedOptions.Clear();
                _serializedGameObjectOptions.Clear();
            }

            _options = value;

            if (Application.isEditor)
                SerializeOptions();
        }
    }

    [SerializeField]
    private ActionDicitonary _serializedOptions;

    [SerializeField]
    private ActionGameObjectDicitonary _serializedGameObjectOptions;

    public void Initialize(InteractiveObject owner)
    {
        DeserializeOptions();
        _serializedOptions.Clear();
        _serializedOptions = null;
        _serializedGameObjectOptions.Clear();
        _serializedGameObjectOptions = null;

        if (action)
            action.owner = owner;
    }

    private void DeserializeOptions()
    {
        if (action == null || _serializedOptions == null)
            return;

        if (_options == null)
            _options = action.GetOptions();

        if (_options == null)
            return;

        foreach (var field in _options.GetType().GetFields(BindingFlags.Instance |
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.Public))
        {
            if (field.FieldType == typeof(GameObject))
            {
                if (_serializedGameObjectOptions.ContainsKey(field.Name))
                    field.SetValue(_options, _serializedGameObjectOptions[field.Name]);
            }
            else if (_serializedOptions.ContainsKey(field.Name))
            {
                var fieldType = field.FieldType;
                TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldType);
                object fieldValue = typeConverter.ConvertFromString(_serializedOptions[field.Name]);
                field.SetValue(_options, fieldValue);
            }
        }
    }

    private void SerializeOptions()
    {
        if (_options == null)
            return;

        if (_serializedOptions == null)
        {
            _serializedOptions = new ActionDicitonary();
            _serializedGameObjectOptions = new ActionGameObjectDicitonary();
        }

        foreach (var field in _options.GetType().GetFields(BindingFlags.Instance |
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.Public))
        {
            if (field.FieldType == typeof(GameObject))
            {
                _serializedGameObjectOptions[field.Name] = (GameObject)field.GetValue(_options);
            }
            else
            {
                var value = field.GetValue(_options);
                if (value != null)
                    _serializedOptions[field.Name] = value.ToString();
            }
        }
    }
}
