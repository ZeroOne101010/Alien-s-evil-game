using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMoveGround : EntityAnimation
{

    public string nameGround = "Ground";
    public string nameSpeedRun = "SpeedRun";
    public string nameJump = "SpeedJump";

    public override void animationStart()
    {
        base.animationStart();
    }


    public override void animationUpdate()
    {
        base.animationUpdate();
        if (rigid.velocity.y == 0)
        {
            animator.SetBool(nameGround, true);
        }
        else
        {
            animator.SetBool(nameGround, false);
        }
        animator.SetFloat(nameSpeedRun, Mathf.Abs(rigid.velocity.x));
        animator.SetFloat(nameJump, rigid.velocity.y);
      
    }
}
