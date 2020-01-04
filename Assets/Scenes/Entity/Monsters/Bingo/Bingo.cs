using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingo : Entity
{

    public Collider2D[] attackTrigger;

    public override void entityStart()
    {
        speedMove = 5;
        addTask(new AIMelleAttak(gameObject, new string[2] {"Attack", "Attack1"}, new float[2] {50, 40}, new float[2] {40, 10}, new float[2] {30, 40}, 10));
        addTask(new AIAttackEnemy(gameObject, false));
        base.entityStart();
    }

    public override void entityUpdate()
    {
        base.entityUpdate();
    }

}
