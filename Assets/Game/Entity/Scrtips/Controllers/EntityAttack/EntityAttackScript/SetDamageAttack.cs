using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamageAttack : EntityAttack
{

    public float damage = 1;

    public override void attackStart()
    {
        base.attackStart();
    }

    public override void attackUpdate()
    {
        base.attackUpdate();
    }

    protected override void attackImplementation(GameObject entity)
    {
        base.attackImplementation(entity);
        EntityController entityController = entity.GetComponent<EntityController>();
        entityController.setDamage(damage);
    }

}
