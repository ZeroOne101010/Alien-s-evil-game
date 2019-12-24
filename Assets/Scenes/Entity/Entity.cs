using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Vector2 size;
    public float speedMove;
    public Animator animator;
    public int health;
    public int damage;


    void Update()
    {
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();
        Animation();
        Death();
    }
    void Death()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Animation()
    {
        if (GetComponent<Rigidbody2D>() != null)
            if (GetComponent<Rigidbody2D>().velocity.x == 0)
            {
                animator.SetBool("Stay", true);
            }
            else
            {
                animator.SetBool("Stay", false);
            }
    }
}
