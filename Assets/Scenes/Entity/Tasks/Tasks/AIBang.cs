using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBang : AITask
{
    private Animator anim;
    public GameObject gameObject;

    public AIBang(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override void updateTask()
    {

    }

    public override void onTrigger2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() && collision.GetComponent<Entity>().TagOfGameEntity == "Player")
        {
            anim = gameObject.GetComponentInParent<Animator>();
            anim.SetBool("Explosion", true);
            collision.GetComponent<Entity>().health -= 50;
            gameObject.GetComponentInParent<Entity>().health = 0;
        }
        base.onTrigger2D(collision);
    }
}
