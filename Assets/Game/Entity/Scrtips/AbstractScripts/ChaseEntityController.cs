using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChaseEntityController : EntityController
{
    public float distanceToFindTarget = 10;
    public float distanceToAttackTarget = 2;

    [HideInInspector]
    public GameObject target;

    private EntityAttackController entityAttackController;
    private AnimationController animationController;

    public override void entityStart()
    {
        base.entityStart();
        entityAttackController = GetComponent<EntityAttackController>();
        animationController = GetComponent<AnimationController>();
    }

    public override void entityUpdate()
    {
        base.entityUpdate();
    }


    public GameObject getTarget()
    {
        GameObject target = null;
        GameObject[] allEntitys = GameObject.FindGameObjectsWithTag("Entity");
        List<GameObject> enemyEntity = new List<GameObject>();
        for (int x = 0; x < allEntitys.Length; x++)
        {
            EntityController entityController = allEntitys[x].GetComponent<EntityController>();
            if (teamId != entityController.teamId)
            {
                enemyEntity.Add(allEntitys[x]);
            }
        }

        for (int x = 0; x < enemyEntity.Count; x++)
        {
            float distance = Vector2.Distance(transform.position, enemyEntity[x].transform.position);
            if (distance < distanceToFindTarget)
            {
                target = enemyEntity[x];
            }
            break;
        }

        return target;
    }

    public void attackTarget()
    {
        entityAttackController.randomAttack(target);
    }

    public virtual void moveToTarget()
    {
        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance < distanceToFindTarget)
            {
                if (distance > distanceToAttackTarget)
                {
                    Vector2 direction = (Vector2)((target.transform.position - transform.position)).normalized;
                    entityMoveController.movePerson(direction);
                }
                else
                {
                    entityMoveController.stopMovePerson();
                    attackTarget();
                }
            }
            else
            {
                target = null;
            }
        }
        else
        {
            entityMoveController.stopMovePerson();
            target = getTarget();
        }
    }
}
