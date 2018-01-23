using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionProperty
{
    public BaseAction action;
    
    [SerializeField]
    public ActionOptions options;
}
