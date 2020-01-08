using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMoveFly : EntityMove
{
    private static float k = 0.05f;

    public void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public override void jumpPerson()
    {
        transform.position += new Vector3(0, 0, forceJump * k);
    }

    public override void movePerson(Vector2 direction)
    {
        transform.position += (Vector3)(direction * speedMove * k);
    }

    public override void stopMovePerson()
    {
        
    }
}
