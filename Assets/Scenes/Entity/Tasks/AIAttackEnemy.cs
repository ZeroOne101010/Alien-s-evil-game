using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackEnemy : MonoBehaviour
{

    public string boolAnimName;
    public float distanceToTakeTarget = 10;
    public bool isAttacking = true;

    public GameObject target;
    public static float timeToTest = 30;
    public bool isRight = true;

    private Animator animator;
    private ManagerForHashEntity hashEntity;
    private float timer;
    private bool isMoving;

    void Start()
    {
        hashEntity = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerForHashEntity>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer--;
        if (timer < 0) timer = 0;

        if (isAttacking)
        {
            if (timer == 0)
            {
                chooseTarget();
                timer = timeToTest;
            }
            moveToTarget();
        }
    }

    public void moveToTarget()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (target != null)
        {
            if (rigid != null)
            {
                isMoving = true;
                float speed = GetComponent<Entity>().speedMove;
                float offset = 0;
                Collider2D col = target.GetComponent<Collider2D>();
                if (col != null)
                {
                    offset = target.GetComponent<Collider2D>().bounds.size.x;
                }
                if (target.transform.position.x + offset < transform.position.x)
                {
                    rigid.velocity = new Vector2(-speed, rigid.velocity.y);
                    if (isRight)
                    {
                        transform.localScale = new Vector3(-Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    if (animator != null)
                    {
                        animator.SetBool(boolAnimName, true);
                    }
                }
                else if (target.transform.position.x - offset > transform.position.x)
                {
                    rigid.velocity = new Vector2(speed, rigid.velocity.y);
                    if (isRight)
                    {
                        transform.localScale = new Vector3(Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    if (animator != null)
                    {
                        animator.SetBool(boolAnimName, true);
                    }
                }
                else
                {
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                    if (animator != null)
                    {
                        animator.SetBool(boolAnimName, false);
                    }
                    AIMelleAttak attack = GetComponent<AIMelleAttak>();
                    if (attack != null)
                    {
                        attack.activeRandomAttack();
                    }
                }
            }
        }
        else
        {
            if (isMoving)
            {
                rigid.velocity = new Vector2(0, rigid.velocity.y);
                isMoving = false;
                if (animator != null)
                {
                    animator.SetBool(boolAnimName, false);
                }
            }
        }
    }

    public void findTarget()
    {
        for(int x = 0; x < hashEntity.entity.Count; x++)
        {
            Entity entity = hashEntity.entity[x];
            if (entity.teamId != GetComponent<Entity>().teamId)
            {
                Vector2 entityPos = new Vector2(entity.transform.position.x, entity.transform.position.y);
                Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                float distance = Vector2.Distance(entityPos, pos);
                if (distance < distanceToTakeTarget)
                {
                    target = entity.gameObject;
                }
            }
        }
    }

    public void chooseTarget()
    {
        for (int x = 0; x < hashEntity.entity.Count; x++)
        {
            Entity entity = hashEntity.entity[x];
            if (entity.teamId != GetComponent<Entity>().teamId)
            {
                Vector2 entityPos = new Vector2(entity.transform.position.x, entity.transform.position.y);
                Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                float distance = Vector2.Distance(entityPos, pos);
                if (distance < distanceToTakeTarget)
                {
                    target = entity.gameObject;
                }
                else
                {
                    if (target == entity.gameObject)
                    {
                        target = null;
                    }
                }
            }
        }
    }
}
