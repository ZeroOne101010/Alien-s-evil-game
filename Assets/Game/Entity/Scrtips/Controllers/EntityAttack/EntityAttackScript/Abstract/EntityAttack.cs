using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAttack : MonoBehaviour
{

    public int timeToActiveAttackAfterAnimation;
    public float probablyChooseAttack = 100;
    public bool canRandomUse = true;

    protected EntityAttackController entityAttackController;
    protected AnimationController animationController;
    protected Animator animator;

    private int timerToActiveAnimationAttack;
    private bool isActiveAnimationAttack;
    private GameObject attackEntity;
    private string animationName;

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
        animator = GetComponent<Animator>();
        timerToActiveAnimationAttack = timeToActiveAttackAfterAnimation;
    }

    public void activeAttackAnimation(string name)
    {
        animationName = name;
    }

    private void activeAnimation()
    {
        animator.SetTrigger(animationName);
        animationName = null;
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
            toReloadAttack();
            if (animationName != null)
            {
                activeAnimation();
            }
            timerToActiveAnimationAttack = timeToActiveAttackAfterAnimation;
            isActiveAnimationAttack = true;
        }
    }

    protected virtual void attackImplementation(GameObject entity)
    {

    }
}
