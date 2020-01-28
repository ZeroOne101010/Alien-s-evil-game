using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnCollisionDeath : EntityDeathEffect
{
    public int timeToUnctive;

    private int timerToUnactive;
    private Collider2D objCollider;
    private Rigidbody2D rigid;

    public override void effectStart()
    {
        base.effectStart();
        objCollider = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
        timerToUnactive = timeToUnctive;
    }

    public override void effectUpdate()
    {
        base.effectUpdate();
        timerToUnactive--;
        if (timerToUnactive < 0) timerToUnactive = 0;
        if (timerToUnactive == 0)
        {
            if (rigid != null)
            {
                rigid.simulated = false;
            }
            if (objCollider != null)
            {
                objCollider.isTrigger = true;
            }
        }
    }
}
