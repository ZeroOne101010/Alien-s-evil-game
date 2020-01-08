using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{

    public float speedMove;
    public float forceJump;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void movePerson(bool isRight)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (isRight)
        {
            rigid.velocity = new Vector2(speedMove, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(-speedMove, rigid.velocity.y);
        }
    }

    public void jumpPerson()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if(rigid.velocity.y == 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, forceJump);
        }
    }

    public void stopMovePerson()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, rigid.velocity.y);
    }
}
