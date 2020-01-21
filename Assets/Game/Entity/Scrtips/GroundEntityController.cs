using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntityController : ChaseEntityController
{

    public override void entityStart()
    {
        base.entityStart();
    }

    public override void entityUpdate()
    {
        base.entityUpdate();
        moveToTarget();
    }

    
}
