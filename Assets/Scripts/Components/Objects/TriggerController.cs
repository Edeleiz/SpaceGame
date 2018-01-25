using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [HideInInspector]
    public GameObject owner;

    public ActionProperty actionProperty;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var action = actionProperty != null ? actionProperty.action : null;
        if (action && action.Check(collider.gameObject, actionProperty.options))
            action.Apply(gameObject, actionProperty.options);
    }

    protected virtual void OnDestroy()
    {
        owner = null;
        actionProperty = null;
    }
}
