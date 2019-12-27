using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Vector2 size;
    public float speedMove;
    public Animator animator;
    public float health;
    public float damage;

    public int teamId = -1;

    private ManagerForHashEntity hashEntity;

    void Start()
    {
        hashEntity = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerForHashEntity>();
        hashEntity.addEntity(this);
    }

    void Update()
    {
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();
        Animation();
    }
    void Death()
    {
        hashEntity.removeEntity(this);
        Destroy(gameObject);
    }

    public void getDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }

    void Animation()
    {
        //if (GetComponent<Rigidbody2D>() != null)
        //    if (GetComponent<Rigidbody2D>().velocity.x == 0)
        //    {
        //        animator.SetBool("Stay", true);
        //    }
        //    else
        //    {
        //        animator.SetBool("Stay", false);
        //    }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Entity entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            AIMelleAttak melee = collision.gameObject.GetComponent<AIMelleAttak>();
            if (melee != null)
            {
                if (melee != GetComponent<AIMelleAttak>())
                if (melee.attaking)
                {
                        if (melee.idAttack != -1)
                        {
                            getDamage(melee.attackDamage[melee.idAttack]);
                        }
                }
            }
        }
    }
}
