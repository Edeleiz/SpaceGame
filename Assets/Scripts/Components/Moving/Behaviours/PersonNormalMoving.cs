using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonMovingBehaviour", menuName = "My Components/Behaviours/Moving/Person", order = 1)]
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
