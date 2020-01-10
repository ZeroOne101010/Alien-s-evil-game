using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFly : EntityAnimation
{

    public string nameVelocityY = "VelocityY";
    public string nameVelocityX = "VelocityX";
    public string nameStay = "Stay";



    public override void animationStart()
    {
        base.animationStart();
    }

    public override void animationUpdate()
    {
        animator.SetFloat(nameVelocityY, rigid.velocity.y);
        animator.SetFloat(nameVelocityX, rigid.velocity.x);
        if(rigid.velocity.x == 0 && rigid.velocity.y == 0)
        {
            animator.SetBool(nameStay, true);
        }
        else
        {
            animator.SetBool(nameStay, false);
        }
    }

}
