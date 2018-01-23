using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestAction", menuName = "My Components/Actions/Test2", order = 2)]
public class GetItemsFromInventoryAction : BaseAction
{
    public override bool Check(GameObject target)
    {
        return true;
    }

    public override void Apply(GameObject target)
    {
        Debug.Log("Test Action!");
    }
}
