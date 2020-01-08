using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonUserController : MonoBehaviour
{
    private EntityMove personController;

    void Start()
    {
        personController = GetComponent<EntityMove>();
    }

    void Update()
    {
        checkMoveUser();
        checkJumpUser();
    }

    public void checkMoveUser()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            personController.movePerson(new Vector2(1, 0));
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            personController.movePerson(new Vector2(-1, 0));
        }
        else
        {
            personController.stopMovePerson();
        }
    }

    public void checkJumpUser()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            personController.jumpPerson();
        }
    }
}
