using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStash : BaseAction
{
    public override bool Check(GameObject target, ActionOptions options)
    {
        return base.Check(target, options);
    }

    public override void Apply(GameObject target, ActionOptions options)
    {
        if (SpicerGameManager.instance.gameMode == GameMode.Junkie)
        {
            var stash = owner.GetComponent<StashObject>();
            if (stash && stash.hasItem)
            {
                Debug.Log("Got it!");
            }
        }
        else
        {
            Debug.Log("Put it!");
        }
    }
}
