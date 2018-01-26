using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestAction", menuName = "My Components/Actions/Test", order = 1)]
public class TestAction : BaseAction
{
    public override bool Check(GameObject target, ActionOptions options)
    {
        return true;
    }

    public override void Apply(GameObject target, ActionOptions options)
    {
        Debug.Log("Test Action!");
        var testOptions = (TestOptions)options;
        if (testOptions != null && testOptions.testObject != null)
            Destroy(testOptions.testObject);
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
    public GameObject testObject;
}

