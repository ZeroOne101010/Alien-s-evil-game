using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveController : MonoBehaviour
{

    public float speedMove;
    public float forceJump;

    private EntityMove[] entityMove;

    void Start()
    {
        entityMove = GetComponents<EntityMove>();
    }

    void Update()
    {
        
    }

    public void movePerson(Vector2 direction)
    {
        for(int x = 0; x < entityMove.Length; x++)
        {
            entityMove[x].movePerson(direction);
        }
    }

    public void jumpPerson()
    {
        for(int x = 0; x < entityMove.Length; x++)
        {
            entityMove[x].jumpPerson();
        }
    }

    public void stopMovePerson()
    {
        for (int x = 0; x < entityMove.Length; x++)
        {
            entityMove[x].stopMovePerson();
        }
    }
}
