using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAnimation : MonoBehaviour
{

    protected Rigidbody2D rigid;
    protected Animator animator;

    public string nameHaveWeapon = "HaveWeapon";

    public void activeWeapon(bool enable)
    {
        animator.SetBool(nameHaveWeapon, enable);
    }

    public virtual void animationStart()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public abstract void animationUpdate();
}
