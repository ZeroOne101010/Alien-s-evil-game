using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationController : MonoBehaviour
{

    public int idActiveController = 0;

    [HideInInspector]
    public EntityAnimation[] entityAnimation;

    void Start()
    {
        entityAnimation = GetComponents<EntityAnimation>();

        for(int x = 0; x < entityAnimation.Length; x++)
        {
            entityAnimation[x].animationStart();
        }
        controllerStart();
    }

    void Update()
    {
        if (entityAnimation[idActiveController] != null)
        {
            entityAnimation[idActiveController].animationUpdate();
        }
        controllerUpdate();
    }

    public virtual void controllerStart()
    {

    }

    public virtual void controllerUpdate()
    {

    }
}
