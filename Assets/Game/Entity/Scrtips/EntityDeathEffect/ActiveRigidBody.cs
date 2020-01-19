using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRigidBody : EntityDeathEffect
{

    private Rigidbody2D rigid;
    private BoxCollider2D[] boxCollider;

    public override void effectStart()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponents<BoxCollider2D>();

        rigid.gravityScale = 1;
        rigid.simulated = true;
        //for(int x = 0; x < boxCollider.Length; x++)
        //{
        //    boxCollider[x].isTrigger = false;
        //}
    }

    public override void effectUpdate()
    {

    }
}
