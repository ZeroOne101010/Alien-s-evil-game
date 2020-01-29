using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityMove : MonoBehaviour
{
    [HideInInspector]
    protected EntityMoveController entityMoveController;

    [HideInInspector]
    protected bool isRight
    {
        get
        {
            return entityMoveController.isRight;
        }
        set
        {
            entityMoveController.isRight = value;
        }
    }

    public void Start()
    {
        entityMoveController = GetComponent<EntityMoveController>();
        entityMoveStart();
    }

    public void Update()
    {
        entityMoveUpdate();
        if (!entityMoveController.inverseRight)
        {
            if (isRight)
            {
                transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            }
            else
            {
                transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            }
        }
        else
        {
            if (!isRight)
            {
                transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            }
            else
            {
                transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            }
        }

    }

    public virtual void entityMoveStart()
    {

    }

    public virtual void entityMoveUpdate()
    {

    }

    public abstract void movePerson(Vector2 direction);
    public abstract void jumpPerson();
    public abstract void stopMovePerson();
    

}
