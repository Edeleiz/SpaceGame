using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    
    public static GameStateManager instance
    {
        private set
        {
            if (_instance != null)
                throw new System.Exception("Game State Manager is singleton!");
            _instance = value;
        }
        get
        {
            return _instance;
        }
    }


    public GameObject playerPrefab;

    [HideInInspector]
    public Vector2 playerRespawnPoint;

    private int _spawnId;

    // Use this for initialization
    void Start ()
    {
        if (_instance == null)
        {
            instance = this;
            SwitchScene("MainScene", 0);
            this.SpawnPlayer();
        }
        SceneManager.sceneLoaded += OnSceneLoadComplete;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool SwitchScene(string sceneName, int spawnId = -1)
    {
        _spawnId = spawnId;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadScene(sceneName));
        return true;
    }

    private void OnSceneLoadComplete(Scene scene, LoadSceneMode sceneMode)
    {
        SceneManager.MoveGameObjectToScene(this.gameObject, scene);
        SpawnPlayer(_spawnId);
    }

    IEnumerator LoadScene(string sceneName)
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public bool SpawnPlayer(int spawnId = -1)
    {
        PlayerSpawn startPoint = null;
        if (spawnId < 0)
        {
            startPoint = FindObjectOfType<PlayerSpawn>();
        }
        else
        {
            var spawns = FindObjectsOfType<PlayerSpawn>();
            foreach (var spawn in spawns)
            {
                if (spawn.id == spawnId)
                {
                    startPoint = spawn;
                    break;
                }
            }
        }

        if (startPoint != null)
        {
            playerRespawnPoint = startPoint.transform.position;
            //startPoint.LevelStarted();
            Instantiate(playerPrefab, playerRespawnPoint, playerPrefab.transform.rotation);
            return true;
        }
        else
        {
            return false;
        }
    }
}

