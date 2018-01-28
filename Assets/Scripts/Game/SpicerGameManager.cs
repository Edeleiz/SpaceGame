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

    public bool IsLocationFound = false;
    public bool IsStasherUIShow = false;

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

    public void Interact()
    {
        if (gameMode == GameMode.Junkie)
        {
            var x = (int)player.gameObject.transform.position.x;
            var y = (int)player.gameObject.transform.position.y;
            print("check coordinates " + x + " " + y);
            if (treasureData.X == x && treasureData.Y == y)
            {
                IsLocationFound = true;
            }
        }

        if (gameMode == GameMode.Stasher)
        {
            IsStasherUIShow = true;
        }
    }

    public void SendLocation(string message)
    {
        var scene = SceneManager.GetActiveScene();
        var testData = new TreasureData();
        testData.X = (int)player.gameObject.transform.position.x;
        testData.Y = (int)player.gameObject.transform.position.y;
        testData.Message = message;
        testData.LocationName = scene.name;
        Server.Instance.SendTreasureData(testData, isSuccess =>
        {
            if (isSuccess)
                Debug.Log("success!");
        });
    }
}

public enum GameMode
{
    Stasher,
    Junkie
}

