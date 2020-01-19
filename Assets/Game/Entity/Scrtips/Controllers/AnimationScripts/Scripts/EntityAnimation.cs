using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAnimation : MonoBehaviour
{

    protected Rigidbody2D rigid;
    protected Animator animator;
    private EntityController entityController;

    public string nameHaveWeapon = "HaveWeapon";
    public string nameDeath = "Death";

    public void activeWeapon(bool enable)
    {
        animator.SetBool(nameHaveWeapon, enable);
    }

    public virtual void animationStart()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityController = GetComponent<EntityController>();
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
    }
}
