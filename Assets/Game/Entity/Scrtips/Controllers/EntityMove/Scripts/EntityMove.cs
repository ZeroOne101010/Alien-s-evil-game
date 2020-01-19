using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityMove : MonoBehaviour
{
    public bool isRight;
    protected EntityMoveController entityMoveController;

    public void Start()
    {
        entityMoveController = GetComponent<EntityMoveController>();
        entityMoveStart();
    }

    public void Update()
    {
        entityMoveUpdate();
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
