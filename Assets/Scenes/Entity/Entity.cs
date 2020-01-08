using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    System.Random rnd = new System.Random();

    [HideInInspector]
    public Vector2 size;

    public float speedMove;
    public float jumpForce;
    public float health = 10;

    [HideInInspector]
    public Animator animator;


    [HideInInspector]
    public float damage;

    [HideInInspector]
    public int countOfCoinFromDeath;

    public GameObject Coin;

    [HideInInspector]
    public int Exp;

    [HideInInspector]
    public string TagOfGameEntity;

    public int teamId = -1;

    private ManagerForHashEntity hashEntity;

    [HideInInspector]
    public List<AITask> task;

    [HideInInspector]
    public bool isDead;

    private int deathTime = 100;
    private int deathTimer;

    void Start()
    {
        hashEntity = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerForHashEntity>();
        hashEntity.addEntity(this);
        if (GetComponent<Animator>() != null)
            animator = GetComponent<Animator>();
        task = new List<AITask>();
        entityStart();
    }

    void Update()
    {
        if (!isDead)
        {
            Animation();
            entityUpdate();
            for (int x = 0; x < task.Count; x++)
            {
                task[x].updateTask();
            }
        }
        else
        {
            deathUpdate();
        }
    }

    public void addTask(AITask task)
    {
        this.task.Add(task);
    }

    public void removeTask(AITask task)
    {
        this.task.Remove(task);
    }

    void Death()
    {
        if (!isDead)
        {
            if (health < 1)
            {
                hashEntity.removeEntity(this);
                for (int i = 0; i < countOfCoinFromDeath; i++)
                {
                    GameObject coint;
                    coint = Instantiate(Coin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    coint.GetComponent<Rigidbody2D>().AddForce(new Vector2(rnd.Next(-2, 1), 1), ForceMode2D.Impulse);
                }
                PlayerPrefs.SetInt("Exp", PlayerPrefs.GetInt("Exp") + Exp);
                isDead = true;
                deathTimer = deathTime;
                deathStart();
            }
        }      
    }

    /* 
    * Этот метод будет юзаться сразу после смерти entity
    * Здесь можно включить анимацию или заспавнить какой нибудь объект
    */
    public virtual void deathStart()
    {
        if (animator != null)
        {
            animator.SetBool("Death", true);
        }
    }
    /*
     * Обнавлнеие entity после того, как оно погинет
     */
    public virtual void deathUpdate()
    {
        deathTimer--;
        if (deathTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    public void getDamage(float damage)
    {
        health -= damage;
        Death();
    }

    void Animation()
    {

    }

    public virtual void entityStart()
    {

    }

    public virtual void entityUpdate()
    {

    }


    /*
     * В будущем обязательно стоит добавить разные виды тасков под мелишную отаку.
     * Так можно будет добавить разнообразные эффекты при ударе, начиная от партиклей,
     * заканчивая привращением врага в другой объект. 
     * Под разными вида имееется ввиду атаки, которые будут наследоваться от класса AIMeleeAttak,
     * при этом этот класс стоит сделать абстракным. Я бы даже сказал не стоит, а обязательно
     * Эт шоб не забыть =)
     */
    public void OnTriggerStay2D(Collider2D collision)
    {
        for(int x = 0; x < task.Count; x++)
        {
            task[x].onTrigger2D(collision);
        }
        Entity entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            AIMelleAttak melee = null;

            for(int x = 0; x < entity.task.Count; x++)
            {
                if(entity.task[x] is AIMelleAttak)
                {
                    melee = entity.task[x] as AIMelleAttak;
                    break;
                }
            }


            if (melee != null)
            {
                if (melee.k2)
                {
                    if (melee.attackId != -1)
                    {
                        if (!melee.alreadyAttackingEntity.Contains(this))
                        {
                            getDamage(melee.attackDamage[melee.attackId]);
                            melee.alreadyAttackingEntity.Add(this);
                        }
                    }
                }
            }
        }
    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        for(int x = 0; x < task.Count; x++)
        {
            task[x].onCollider2D(collision);
        }
    }
}
