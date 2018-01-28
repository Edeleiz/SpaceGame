using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpicerGameManager : GameStateManager
{
    public static new SpicerGameManager instance
    {
        get { return (SpicerGameManager)_instance; }
    }


    public GameMode gameMode;

    public TreasureData treasureData;

	// Use this for initialization
	void Start ()
    {
        GameStateManager.instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void InitGameMode()
    {
        var scene = SceneManager.GetSceneAt(1);
        SwitchScene(scene.name);
    }
}

public enum GameMode
{
    Stasher,
    Junkie
}

