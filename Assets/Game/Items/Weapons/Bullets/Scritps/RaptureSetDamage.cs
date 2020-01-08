using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptureSetDamage : BulletRapture
{

    public float damage;

    public override void bulletRapture(GameObject entity)
    {
        EntityController state = entity.GetComponent<EntityController>();
        state.setDamage(damage);
    }

    public override void destroyBullet()
    {
        Destroy(gameObject);
    }
}
