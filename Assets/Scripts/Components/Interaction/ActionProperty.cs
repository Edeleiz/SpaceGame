using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionProperty
{
    public BaseAction action;

    private ActionOptions _options;
    public ActionOptions options
    {
        get { return _options; }
        set { _options = value; }
    }

    public ArrayList optionValues;
}
