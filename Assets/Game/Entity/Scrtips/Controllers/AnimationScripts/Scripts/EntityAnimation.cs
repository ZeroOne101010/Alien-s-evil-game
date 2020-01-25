using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAnimation : MonoBehaviour
{

    protected Rigidbody2D rigid;
    protected Animator animator;
    private EntityController entityController;
    private EntityMoveController entityMoveCtonroller;

    public string[] nameAnimationAttack;
    public string nameHaveWeapon = "HaveWeapon";
    public string nameDeath = "Death";
    public string nameFloatRight = "FloatRight";
    public string nameVelocity = "Velocity";

    public void activeWeapon(bool enable)
    {
        animator.SetBool(nameHaveWeapon, enable);
    }

    public void setAnimationAttack(bool value, int id)
    {
        if(nameAnimationAttack.Length > 0)
        animator.SetBool(nameAnimationAttack[id], value);
    }

    public virtual void animationStart()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityController = GetComponent<EntityController>();
        entityMoveCtonroller = GetComponent<EntityMoveController>();
    }

    public virtual void animationUpdate()
    {
        if (entityController.isDeath)
        {
            animator.SetBool(nameDeath, true);
        }
        else
        {
            animator.SetBool(nameDeath, false);
        }

        animator.SetBool(nameFloatRight, entityMoveCtonroller);
    }
}
