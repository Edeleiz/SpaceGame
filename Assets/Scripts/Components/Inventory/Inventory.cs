using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class ItemsDicitonary : SerializableDictionary<BaseItem, int> { }

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private ItemsDicitonary items;

    private List<BaseItem> _itemsList;

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
        AddItem(item, 1);
        return true;
    }

    public bool AddItem(BaseItem item, int count)
    {
        items[item] += count;
        _itemsList = null;
        return true;
    }

    public bool Removetem(BaseItem item)
    {
        RemoveItem(item, 1);
        return true;
    }

    public bool RemoveItem(BaseItem item, int count)
    {
        if (items.ContainsKey(item) == false)
            return false;
        items[item] -= count;
        if (items[item] < 0)
            items.Remove(item);
        _itemsList = null;
        return true;
    }

    public int GetItemCount(BaseItem item)
    {
        if (items.ContainsKey(item) == false)
            return 0;
        return items[item];
    }

    public List<BaseItem> GetItems()
    {
        if (_itemsList != null)
            return _itemsList;

        _itemsList = new List<BaseItem>();

        foreach (var pair in items)
        {
            _itemsList.Add(pair.Key);
        }

        return _itemsList;
    }

    protected virtual void OnDestroy()
    {
        if (items != null)
            items.Clear();
        items = null;
        if (_itemsList != null)
            _itemsList.Clear();
        _itemsList = null;
    }
}