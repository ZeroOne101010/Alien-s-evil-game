using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAttack : MonoBehaviour
{

    public int timeToActiveAttackAfterAnimation;
    public int idAnimationAttack;
    public float probablyChooseAttack = 100;
    public bool canRandomUse = true;

    protected EntityAttackController entityAttackController;
    protected AnimationController animationController;

    private int timerToActiveAnimationAttack;
    private bool isActiveAnimationAttack;
    private GameObject attackEntity;

    protected bool attackIsReloaded
    {
        get
        {
            return entityAttackController.attackIsReloaded;
        }
        set
        {
            entityAttackController.attackIsReloaded = value;
        }
    }

    public virtual void attackStart()
    {
        animationController = GetComponent<AnimationController>();
        entityAttackController = GetComponent<EntityAttackController>();
        timerToActiveAnimationAttack = timeToActiveAttackAfterAnimation;
    }

    public virtual void attackUpdate()
    {
        timerToActiveAnimationAttack--;
        if (timerToActiveAnimationAttack < 0) timerToActiveAnimationAttack = 0;
        if(timerToActiveAnimationAttack == 0 && isActiveAnimationAttack)
        {
            attackImplementation(attackEntity);
            isActiveAnimationAttack = false;
        }
    }

    public void toReloadAttack()
    {
        entityAttackController.toReloadAttack();
    }

    public void attack(GameObject entity)
    {
        if (attackIsReloaded)
        {
            attackEntity = entity;
            animationController.setAnimationAttack(idAnimationAttack);
            toReloadAttack();
            timerToActiveAnimationAttack = timeToActiveAttackAfterAnimation;
            isActiveAnimationAttack = true;
        }
    }

    protected virtual void attackImplementation(GameObject entity)
    {

    }
}
