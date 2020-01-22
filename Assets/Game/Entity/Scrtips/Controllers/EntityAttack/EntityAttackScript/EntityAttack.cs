using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityAttack : MonoBehaviour
{

    protected AnimationController animationController;

    public virtual void attackStart()
    {
        animationController = GetComponent<AnimationController>();
    }

    public virtual void attackUpdate()
    {
        animationController.setAnimationAttack(false, animationController.idActiveController);
    }

    public virtual void attack(GameObject entity)
    {
        animationController.setAnimationAttack(true, animationController.idActiveController);
    }
}
