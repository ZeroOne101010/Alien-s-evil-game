using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackEnemy : AITask
{

    public GameObject gameObject;

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

    public AIAttackEnemy(GameObject gameObject, bool isRight)
    {
        this.gameObject = gameObject;
        this.isRight = isRight;
        hashEntity = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerForHashEntity>();
        animator = gameObject.GetComponent<Animator>();
    }

    public AIAttackEnemy(GameObject gameObject)
    {
        this.gameObject = gameObject;
        hashEntity = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerForHashEntity>();
        animator = gameObject.GetComponent<Animator>();
    }

    public override void updateTask()
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
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        if (target != null)
        {
            if (rigid != null)
            {
                isMoving = true;
                float speed = gameObject.GetComponent<Entity>().speedMove;
                float offset = 0;
                Collider2D col = target.GetComponent<Collider2D>();
                if (col != null)
                {
                    offset = target.GetComponent<Collider2D>().bounds.size.x;
                }
                if (target.transform.position.x + offset < gameObject.transform.position.x)
                {
                    rigid.velocity = new Vector2(-speed, rigid.velocity.y);
                    if (isRight)
                    {
                        gameObject.transform.localScale = new Vector3(-Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    else
                    {
                        gameObject.transform.localScale = new Vector3(Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    if (animator != null)
                    {
                        animator.SetBool(boolAnimName, true);
                    }
                }
                else if (target.transform.position.x - offset > gameObject.transform.position.x)
                {
                    rigid.velocity = new Vector2(speed, rigid.velocity.y);
                    if (isRight)
                    {
                        gameObject.transform.localScale = new Vector3(Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
                    }
                    else
                    {
                        gameObject.transform.localScale = new Vector3(-Mathf.Abs(target.transform.localScale.x), target.transform.localScale.y, target.transform.localScale.z);
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

                    Entity entity = gameObject.GetComponent<Entity>();

                    AIMelleAttak attack = null;

                    for (int x = 0; x < entity.task.Count; x++)
                    {
                        if (entity.task[x] is AIMelleAttak)
                        {
                            attack = entity.task[x] as AIMelleAttak;
                            break;
                        }
                    }

                    if (attack != null)
                    {
                        attack.activeAttacking();
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
        for (int x = 0; x < hashEntity.entity.Count; x++)
        {
            Entity entity = hashEntity.entity[x];
            if (entity.teamId != gameObject.GetComponent<Entity>().teamId)
            {
                Vector2 entityPos = new Vector2(entity.transform.position.x, entity.transform.position.y);
                Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
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
            if (entity.teamId != gameObject.GetComponent<Entity>().teamId)
            {
                Vector2 entityPos = new Vector2(entity.transform.position.x, entity.transform.position.y);
                Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
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
