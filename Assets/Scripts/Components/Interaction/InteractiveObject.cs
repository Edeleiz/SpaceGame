using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    public ActionProperty actionProperty;

    public BaseAction action
    {
        get { return actionProperty.action; }
        set
        {
            if (actionProperty.action)
                actionProperty.action.owner = null;

            actionProperty.action = value;

            if (actionProperty.action)
                actionProperty.action.owner = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        //action.owner = this;

        var trigger = GetComponentInChildren<TriggerController>();
        if (trigger)
            trigger.owner = this.gameObject;

        actionProperty.Initialize(this);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Interact(GameObject target)
    {
        if (!action)
            return;

        if (action.Check(target, actionProperty.options))
            action.Apply(target, actionProperty.options);
    }

    protected virtual void OnDestroy()
    {
        actionProperty = null;
    }
}
