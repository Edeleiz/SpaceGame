using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public Dictionary<BaseItem, int> items = new Dictionary<BaseItem, int>();

    public bool test;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Debug()
    {

    }

    protected virtual void OnDestroy()
    {
        
    }
}
