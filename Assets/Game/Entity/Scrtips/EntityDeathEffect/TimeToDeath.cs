using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDeath : EntityDeathEffect
{

    public float time;
    private float timer;

    public override void effectStart()
    {
        timer = time;
    }

    public override void effectUpdate()
    {
        timer--;
        if (timer < 0) timer = 0;
        if(timer == 0)
        {
            Destroy(gameObject);
        }
    }
}
