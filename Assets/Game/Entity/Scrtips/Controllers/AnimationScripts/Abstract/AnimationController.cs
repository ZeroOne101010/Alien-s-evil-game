using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationController : MonoBehaviour
{
    [HideInInspector]
    public EntityAnimation[] entityAnimation;

    void Start()
    {
        entityAnimation = GetComponents<EntityAnimation>();
        controllerStart();
    }


    void Update()
    {
        controllerUpdate();
    }

    public virtual void controllerStart()
    {
        for (int x = 0; x < entityAnimation.Length; x++)
        {
            entityAnimation[x].animationStart();
        }
    }

    public virtual void controllerUpdate()
    {
        for (int x = 0; x < entityAnimation.Length; x++)
        {
            entityAnimation[x].animationUpdate();
        }
    }
}
