using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveableObject : MonoBehaviour
{
    public bool isEnabled = true;
    public BaseMovingBehaviour behaviour;

    private Rigidbody2D _target;

	// Use this for initialization
	void Start ()
    {
        _target = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (behaviour && isEnabled)
        {
            behaviour.Update();
        }
	}

    public void Move(Vector2 direction)
    {
        if (!behaviour)
            return;

        behaviour.target = _target;
        behaviour.Move(direction);
    }
}
