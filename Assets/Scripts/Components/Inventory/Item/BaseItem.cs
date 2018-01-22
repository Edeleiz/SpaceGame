using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Item", menuName = "My Components/Items/Base Item", order = 1)]
public class BaseItem : ScriptableObject
{
    public string itemName;

    public bool isStackable;
}
