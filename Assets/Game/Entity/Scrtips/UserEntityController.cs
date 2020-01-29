using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserEntityController : EntityController
{
    private EntityAttackController attackController;
    public Joystick joystick;

    public override void entityStart()
    {
        base.entityStart();
        attackController = GetComponent<EntityAttackController>();
    }

    public override void entityUpdate()
    {
        base.entityUpdate();
        checkMoveUser();
        checkJumpUser();
        attackUser();
    }

    public void checkMoveUser()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            entityMoveController.movePerson(new Vector2(1, 0));
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            entityMoveController.movePerson(new Vector2(-1, 0));
        }
        else if (joystick != null)
        {
            if (joystick.Horizontal > 0.01f)
            {
                entityMoveController.movePerson(new Vector2(joystick.Horizontal, 0));
            }
            else if (joystick.Horizontal < -0.01f)
            {
                entityMoveController.movePerson(new Vector2(joystick.Horizontal, 0));
            }
            else
            {
                entityMoveController.stopMovePerson();
            }
        }
        else
        {
            entityMoveController.stopMovePerson();
        }
        
    }

    public void checkJumpUser()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            entityMoveController.jumpPerson();
        }
    }

    public void attackUser()
    {
        if (Input.GetKey(KeyCode.R))
        {
            attackController.attack(0, null);
        }
    }
}
