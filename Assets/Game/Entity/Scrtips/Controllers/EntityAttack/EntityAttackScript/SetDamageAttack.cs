using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamageAttack : SkillAttack
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
        activeAttackAnimation(nameAnimationAttack);
        EntityController entityController = entity.GetComponent<EntityController>();
        entityController.setDamage(damage);
    }

}
