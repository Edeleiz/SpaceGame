using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAction : ScriptableObject
{
    [HideInInspector]
    public InteractiveObject owner;

    public virtual bool Check(GameObject target)
    {
        return false;
    }

    public virtual void Apply(GameObject target)
    {
        
    }

    public virtual object GetOptions()
    {
        return null;
    }

    protected virtual void OnDestroy()
    {
        owner = null;
    }
}

[System.Serializable]
public class ActionOptions
{ }

