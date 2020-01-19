using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveFly : EntityMove
{
    private static float k = 0.05f;

    public override void entityMoveStart()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public override void jumpPerson()
    {
        transform.position += new Vector3(0, 0, entityMoveController.speedMove * k);
    }

    public override void movePerson(Vector2 direction)
    {
        transform.position += (Vector3)(direction * entityMoveController.speedMove * k);
    }

    public override void stopMovePerson()
    {

    }

}
