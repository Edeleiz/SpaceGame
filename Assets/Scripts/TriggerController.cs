using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [HideInInspector]
    public GameObject owner;

    public BaseAction action;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (action && action.Check(collider.gameObject))
            action.Apply(gameObject);
    }
}
