using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public GameObject playerPrefab;

    [HideInInspector]
    public Vector2 playerRespawnPoint;

    // Use this for initialization
    void Start ()
    {
        this.MakePlayer();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MakePlayer()
    {
        var startPoint = FindObjectOfType<PlayerSpawn>();
        if (startPoint != null)
        {
            playerRespawnPoint = startPoint.transform.position;
            //startPoint.LevelStarted();
        }
        Instantiate(playerPrefab, playerRespawnPoint, playerPrefab.transform.rotation);
    }
}

