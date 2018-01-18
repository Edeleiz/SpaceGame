using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovingBehaviour : UnityEngine.ScriptableObject
{
    protected static void BasicMovement(Rigidbody2D target, Vector3 direction, float speed)
    {
        var animator = target.GetComponentInChildren<Animator>();
        if (animator != null)
        {
            animator.SetBool("is_moving", direction.magnitude > 0);
            if (direction != Vector3.zero)
            {
                animator.SetFloat("input_x", direction.x);
                animator.SetFloat("input_y", direction.y);
            }
        }

        target.velocity = Vector3.ClampMagnitude(direction, 1f) * speed;
        if (Mathf.Abs(direction.x) > 0)
        {
            target.transform.localScale = direction.x < 0f ? new Vector3(1f, 1f, 1f) : new Vector3(-1f, 1f, 1f);
        }
    }

    [HideInInspector]
    public bool isMoving = false;

    [HideInInspector]
    public Rigidbody2D target;

    protected Vector3 _direction;
	
	// Update is called once per frame
	public void Update ()
    {
        if (target == null)
        {
            return;
        }
        UpdateMove();
        isMoving = false;
        _direction = Vector3.zero;
	}

    public void Move(Vector3 direction)
    {
        _direction = direction;
        isMoving = true;
    }

    protected virtual void UpdateMove()
    {

    }
}
