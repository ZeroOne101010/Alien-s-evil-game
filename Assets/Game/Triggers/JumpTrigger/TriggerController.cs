using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Entity")
        {
            EntityMoveController entityMoveController = collision.gameObject.GetComponent<EntityMoveController>();
            if (entityMoveController.canReactionOnEntityTrigger)
            {
                entityMoveController.jumpPerson();
            }
        }
    }

}
