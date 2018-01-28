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

    public GameObject player;

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
            SwitchScene("StartScene", 0);
        }
    }

    private void OnTreasureReceived(TreasureData data)
    {
        Debug.Log("received, " + data.LocationName);
        treasureData = data;
        SwitchScene("StartScene", 0);
    }

    override protected void OnSceneLoadComplete(Scene scene, LoadSceneMode sceneMode)
    {
        SceneManager.MoveGameObjectToScene(this.gameObject, scene);
        var player = SpawnPlayer(_spawnId);

        this.player = player;
    }
}

public enum GameMode
{
    Stasher,
    Junkie
}

