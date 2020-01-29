using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleAnimationController : AnimationController
{

    public string nameDeath = "Death";
    public string nameFloatRight = "FloatRight";
    public string nameVelocity = "Velocity";
    public string nameSpeedRun = "SpeedRun";
    public string nameJump = "Jump";

    private Animator animator;
    private Rigidbody2D rigid;
    private EntityController entityController;

    public override void controllerStart()
    {
        base.controllerStart();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityController = GetComponent<EntityController>();
    }

    public override void controllerUpdate()
    {
        animator.SetFloat(nameSpeedRun, Mathf.Abs(rigid.velocity.x));
        animator.SetFloat(nameJump, rigid.velocity.y);
        animator.SetFloat(nameVelocity, rigid.velocity.x);
        if (entityController.isDeath)
        {
            animator.SetBool(nameDeath, true);
        }
        else
        {
            animator.SetBool(nameDeath, false);
        }
        base.controllerUpdate();
    }

}
