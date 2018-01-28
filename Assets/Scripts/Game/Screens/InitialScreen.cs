using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScreen : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        var gameManager = (SpicerGameManager)GameStateManager.instance;
        if (Input.GetKeyUp(KeyCode.A))
        {
            gameManager.gameMode = GameMode.Stasher;
            gameManager.InitGameMode();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            gameManager.gameMode = GameMode.Junkie;
            gameManager.InitGameMode();
        }
	}
}
