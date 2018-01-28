using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwitchAction", menuName = "My Components/Actions/Scene/SwitchLevel", order = 1)]
public class SwitchLevel : BaseAction
{
    public override bool Check(GameObject target, ActionOptions options)
    {
        return true;
    }

    public override void Apply(GameObject target, ActionOptions options)
    {
        //SceneManager.GetActiveScene();
        var sceneOptions = (SwitchLevelOptions)options;
        GameStateManager.instance.SwitchScene(sceneOptions.sceneName, sceneOptions.spawnId);
    }

    public override ActionOptions GetOptions()
    {
        return new SwitchLevelOptions();
    }
}

[System.Serializable]
public class SwitchLevelOptions : ActionOptions
{
    public string sceneName;

    public int spawnId = 0;
}

