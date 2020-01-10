using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityMove : MonoBehaviour
{
    public float speedMove;
    public float forceJump;

    public bool isRight;

    public abstract void movePerson(Vector2 direction);
    public abstract void jumpPerson();
    public abstract void stopMovePerson();


}
