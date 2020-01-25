using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamageAttack : EntityAttack
{

    public float damage = 1;
    public float attackReloadTime = 10;

    private float attackReloadTimer;

    public override void attackStart()
    {
        base.attackStart();
        attackReloadTimer = attackReloadTime;
    }

    public override void attackUpdate()
    {
        base.attackUpdate();
        attackReloadTimer--;
        if (attackReloadTimer < 0) attackReloadTimer = 0;
    }

    public override void attack(GameObject entity)
    {
        base.attack(entity);
        if (attackReloadTimer == 0)
        {
            EntityController entityController = entity.GetComponent<EntityController>();
            entityController.setDamage(damage);
            attackReloadTimer = attackReloadTime;
        }
    }

}
