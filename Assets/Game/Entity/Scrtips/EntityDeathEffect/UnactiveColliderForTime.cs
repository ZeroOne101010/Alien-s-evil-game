using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnactiveColliderForTime : EntityDeathEffect
{

    public int timeToUnactive;
    private int timerToUnactive;

    private Collider2D[] colliders;

    public override void effectStart()
    {
        base.effectStart();
        timerToUnactive = timeToUnactive;
        colliders = GetComponents<Collider2D>();
    }

    public override void effectUpdate()
    {
        base.effectUpdate();
        timerToUnactive--;
        if (timerToUnactive < 0) timerToUnactive = 0;
        if(timerToUnactive == 0)
        {
            for (int x = 0; x < colliders.Length; x++)
            {
                colliders[x].enabled = false;
            }
        }
    }

}
