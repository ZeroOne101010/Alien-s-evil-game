using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAttack : MonoBehaviour
{

    public int timeToActiveAttackAfterAnimation;
    public float probablyChooseAttack = 100;
    public bool canRandomUse = true;
    public int idShotEffect;

    private ShotEffect shotEffect;

    protected EntityAttackController entityAttackController;
    protected AnimationController animationController;
    protected Animator animator;

    private int timerToActiveAnimationAttack;
    private bool isActiveAnimationAttack;
    private GameObject attackEntity;
    private string animationName;
    private EntityMoveController entityMoveController;

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
        entityMoveController = GetComponent<EntityMoveController>();
        animator = GetComponent<Animator>();
        timerToActiveAnimationAttack = timeToActiveAttackAfterAnimation;
        ShotEffect[] arrayEffect = GetComponents<ShotEffect>();
        if (idShotEffect < arrayEffect.Length)
        {
            shotEffect = GetComponents<ShotEffect>()[idShotEffect];
        }
    }

    public void activeAttackAnimation(string name)
    {
        animationName = name;
    }

    public void useEffect()
    {
        if (shotEffect != null)
        {
            bool isRight = entityMoveController.isRight;
            shotEffect.effect(isRight);
        }
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
        useEffect();
    }
}
