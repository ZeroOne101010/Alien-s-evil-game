using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveRotation : EntityMove
{

    private Rigidbody2D rigid;
    public float kRotation = 0.1f;

    public override void entityMoveUpdate()
    {
        base.entityMoveUpdate();
        //rigid.rotation = rigid.rotation + 10;
    }

    public override void entityMoveStart()
    {
        base.entityMoveStart();
        rigid = GetComponent<Rigidbody2D>();
    }

    public override void jumpPerson()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, entityMoveController.forceJump);
    }

    public override void movePerson(Vector2 direction)
    {
        float kDirection = 0;

        if(direction.x > 0)
        {
            kDirection = 1;
        }
        else if(direction.x < 0)
        {
            kDirection = -1;
        }

        isRight = kDirection == 1 ? true : false;

        rigid.rotation += entityMoveController.speedMove * kRotation * kDirection;
    }

    public override void stopMovePerson()
    {
        rigid.rotation = 0;
    }
}
