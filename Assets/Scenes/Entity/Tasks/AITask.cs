using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AITask
{
    public AITask()
    {

    }

    public abstract void updateTask();

    public virtual void onCollider2D(Collision2D collider)
    {

    }

    public virtual void onTrigger2D(Collider2D collider)
    {

    }

}
