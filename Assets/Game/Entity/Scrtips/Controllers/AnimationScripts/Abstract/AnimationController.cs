using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationController : MonoBehaviour
{

    [HideInInspector]
    public EntityAnimation entityAnimation;

    void Start()
    {
        entityAnimation = GetComponent<EntityAnimation>();
        entityAnimation.animationStart();
        controllerStart();
    }

    public void setAnimationAttack(int id)
    {
        entityAnimation.setAnimationAttack(id);
    }

    void Update()
    {
        entityAnimation.animationUpdate();
        controllerUpdate();
    }

    public virtual void controllerStart()
    {

    }

    public virtual void controllerUpdate()
    {

    }
}
