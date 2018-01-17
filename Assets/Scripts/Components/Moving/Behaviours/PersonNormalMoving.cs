using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonNormalMoving : BaseMovingBehaviour
{
    public float speed = 2.0f;

    public PersonNormalMoving():base()
    {

    }

    protected override void UpdateMove()
    {
        BasicMovement(target, _direction, speed);
    }
}
