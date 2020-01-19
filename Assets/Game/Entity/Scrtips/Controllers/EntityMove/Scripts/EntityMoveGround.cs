using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveGround : EntityMove
{
    public override void jumpPerson()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (rigid.velocity.y == 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, entityMoveController.forceJump);
        }
    }

    public override void movePerson(Vector2 direction)
    {
        if(direction.x > 0)
        {
            isRight = true;
        }
        else if (direction.x < 0)
        {
            isRight = false;
        }

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (isRight)
        {
            rigid.velocity = new Vector2(entityMoveController.speedMove, rigid.velocity.y);
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        }
        else
        {
            rigid.velocity = new Vector2(-entityMoveController.speedMove, rigid.velocity.y);
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        }
    }

    public override void stopMovePerson()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }

}
