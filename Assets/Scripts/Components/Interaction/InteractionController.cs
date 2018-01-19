using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [HideInInspector]
    public bool isInteracted = false;

    [HideInInspector]
    public InteractiveObject interactionTarget;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == Tags.TRIGGER)
        {
            var trigger = collider.GetComponent<TriggerController>();
            if (trigger && trigger.owner)
            {
                var owner = trigger.owner.GetComponent<InteractiveObject>();
                if (owner)
                {
                    isInteracted = true;
                    interactionTarget = owner;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        isInteracted = false;
        interactionTarget = null;
    }

    protected virtual void OnDestroy()
    {
        interactionTarget = null;
    }
}
