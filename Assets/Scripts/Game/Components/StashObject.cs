using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StashObject : MonoBehaviour
{
    public BaseItem stashItem;

    public GameMode gameMode;

    public bool hasItem { get; private set; }


	// Use this for initialization
	void Start ()
    {
        gameMode = SpicerGameManager.instance.gameMode;

        if (gameMode == GameMode.Junkie)
        {
            var treasureData = SpicerGameManager.instance.treasureData;
            var position = this.gameObject.transform.position;

            if (SceneManager.GetActiveScene().name == treasureData.LocationName &&
                position.x == treasureData.X &&
                position.y == treasureData.Y)
            {
                GetComponent<Inventory>().AddItem(stashItem);
                hasItem = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
