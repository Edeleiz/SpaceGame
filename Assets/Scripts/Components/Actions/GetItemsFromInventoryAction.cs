using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestAction", menuName = "My Components/Actions/Test2", order = 2)]
public class GetItemsFromInventoryAction : BaseAction
{
    public override bool Check(GameObject target, ActionOptions options)
    {
        var targetInventory = target.GetComponent<Inventory>();
        var ownerInventory = owner.GetComponent<Inventory>();
        if (targetInventory != null && ownerInventory != null)
            return true;
        return false;
    }

    public override void Apply(GameObject target, ActionOptions options)
    {
        var targetInventory = target.GetComponent<Inventory>();
        var ownerInventory = owner.GetComponent<Inventory>();
        var items = ownerInventory.TakeItems();
        targetInventory.AddItems(items);
    }
}
