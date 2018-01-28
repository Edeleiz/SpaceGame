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
        SceneManager.sceneLoaded += OnSceneLoadComplete;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    public void InitGameMode()
    {
        if (gameMode == GameMode.Junkie)
        {
            Server.Instance.LoadTreasureData(OnTreasureReceived);
        }
        else
        {
            var scene = SceneManager.GetSceneAt(1);
            SwitchScene(scene.name);
        }
    }

    private void OnTreasureReceived(TreasureData data)
    {
        Debug.Log("received, " + data.LocationName);
        treasureData = data;
        SwitchScene("MainScene", 0);
    }
}

public enum GameMode
{
    Stasher,
    Junkie
}

