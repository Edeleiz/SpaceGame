using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CheckStash", menuName = "My Components/Actions/Check Stash", order = 2)]
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
            var scene = SceneManager.GetActiveScene();
            var testData = new TreasureData();
            testData.X = (int)owner.gameObject.transform.position.x;
            testData.Y = (int)owner.gameObject.transform.position.y;
            testData.Message = "Check near the lenin statue at the bushes";
            testData.LocationName = scene.name;
            Server.Instance.SendTreasureData(testData, isSuccess =>
            {
                if (isSuccess)
                    Debug.Log("success!");
            });
        }
    }
}
