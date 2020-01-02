using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public Vector2 size;
    public float speedMove;
    public Animator animator;
    public float health;
    public float damage;
    public int countOfCoinFromDeath;
    public GameObject Coin;
    public int Exp;
    public string TagOfGameEntity;

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
        Death();
    }
    void Death()
    {
        if (health <= 0)
        {
            hashEntity.removeEntity(this);
            for(int i = 0;i < countOfCoinFromDeath; i++)
            {    
                GameObject coint;
                coint = Instantiate(Coin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                coint.GetComponent<Rigidbody2D>().AddForce(new Vector2(rnd.Next(-2,1),1), ForceMode2D.Impulse);
                PlayerPrefs.SetInt("Exp", PlayerPrefs.GetInt("Exp") + Exp);
            }

            Destroy(gameObject);
        }
        
    }

    public void getDamage(float damage)
    {
        health -= damage;
    }

    void Animation()
    {
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
