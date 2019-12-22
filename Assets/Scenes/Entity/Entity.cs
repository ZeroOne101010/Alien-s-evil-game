using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Vector2 size;
    public float speedMove;
    public int health;

    void Start()
    {

    }


    void Update()
    {
        Death();
    }
    void Death()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }



}
