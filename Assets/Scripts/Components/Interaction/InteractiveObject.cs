using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public BaseAction action;
    public BaseAction actionProperty
    {
        get { return action; }
        set
        {
            if (action)
                action.owner = null;

            action = value;

            if (action)
                action.owner = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        action.owner = this;

        var trigger = GetComponentInChildren<TriggerController>();
        if (trigger)
            trigger.owner = this.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Interact(GameObject target)
    {
        if (!action)
            return;

        if (action.Check(target))
            action.Apply(target);
    }

    protected virtual void OnDestroy()
    {
        actionProperty = null;
    }
}
