using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapturePeriodicDamage : BulletRapture
{

    public float damage;
    public float T;
    private float timer;

    public override void bulletRapture(GameObject entity)
    {
        timer--;
        if(timer < 0)
        {
            EntityController controller = entity.GetComponent<EntityController>();
            controller.setDamage(damage);
            timer = T;
        }
    }

    public override void destroyBullet()
    {

    }
}
