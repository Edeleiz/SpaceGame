using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestAction", menuName = "My Components/Actions/Test", order = 1)]
public class TestAction : BaseAction
{
    public override bool Check(GameObject target)
    {
        return true;
    }

    public override void Apply(GameObject target)
    {
        Debug.Log("Test Action!");
    }

    public override ActionOptions GetOptions()
    {
        return new TestOptions();
    }
}

[System.Serializable]
class TestOptions : ActionOptions
{
    [SerializeField]
    public int testInt;

    [SerializeField]
    public string testString;

    [SerializeField]
    public GameObject testObject;
}

