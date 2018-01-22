using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Item", menuName = "My Components/Items/Base Item", order = 1)]
public class BaseItem : ScriptableObject
{
    //Should be uniq name
    public string itemName;

    public bool isStackable;

    public BaseItem Clone()
    {
        var clone = ScriptableObject.CreateInstance<BaseItem>();
        clone.name = this.itemName;
        clone.isStackable = this.isStackable;
        return clone;
    }
}
