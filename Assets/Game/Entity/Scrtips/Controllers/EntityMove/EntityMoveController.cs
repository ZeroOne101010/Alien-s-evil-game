using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveController : MonoBehaviour
{

    public float speedMove;
    public float forceJump;

    public bool inverseRight;

    private EntityMove[] entityMove;

    [HideInInspector]
    public bool isRight;

    public bool canReactionOnEntityTrigger = true;

    void Start()
    {
        entityMove = GetComponents<EntityMove>();
        speedMove = Random.Range(speedMove - speedMove / 5, speedMove);
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
