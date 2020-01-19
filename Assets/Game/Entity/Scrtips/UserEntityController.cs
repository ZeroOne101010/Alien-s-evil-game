using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserEntityController : EntityController
{
    private EntityMove entityMove;
    private EntityAttackController attackController;

    void Start()
    {
        entityMove = GetComponent<EntityMove>();
        attackController = GetComponent<EntityAttackController>();
    }

    void Update()
    {
        checkMoveUser();
        checkJumpUser();
        attackUser();
    }

    public void checkMoveUser()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            entityMove.movePerson(new Vector2(1, 0));
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            entityMove.movePerson(new Vector2(-1, 0));
        }
        else
        {
            entityMove.stopMovePerson();
        }
    }

    public void checkJumpUser()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            entityMove.jumpPerson();
        }
    }

    public void attackUser()
    {
        if (Input.GetKey(KeyCode.R))
        {
            attackController.attack(null);
        }
    }
}
