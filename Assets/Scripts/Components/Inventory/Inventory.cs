using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class ItemsDicitonary : SerializableDictionary<BaseItem, int> { }

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private ItemsDicitonary items;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool AddItem(BaseItem item)
    {
        return true;
    }

    public bool AddItem(BaseItem item, int count)
    {
        return true;
    }

    public bool Removetem(BaseItem item)
    {
        return true;
    }

    public bool RemoveItem(BaseItem item, int count)
    {
        return true;
    }

    public void Debug()
    {

    }

    protected virtual void OnDestroy()
    {
        
    }
}
