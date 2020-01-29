using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAnimation : MonoBehaviour
{

    protected Rigidbody2D rigid;
    protected Animator animator;
    private EntityController entityController;
    private EntityMoveController entityMoveCtonroller;


    public virtual void animationStart()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityController = GetComponent<EntityController>();
        entityMoveCtonroller = GetComponent<EntityMoveController>();
    }

    public virtual void animationUpdate()
    {

    }
}
