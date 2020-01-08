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


    // Start is called before the first frame update
    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animationStart();
    }

    // Update is called once per frame
    public void Update()
    {
        animationUpdate();
    }

    public virtual void animationStart()
    {

    }

    public abstract void animationUpdate();
}
