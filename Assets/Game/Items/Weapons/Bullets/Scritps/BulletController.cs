using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speedMove;
    public float teamId;
    public float timeLive;

    private float timerLive;

    [HideInInspector]
    public Vector2 direction;

    [HideInInspector]
    public GameObject weapon;

    [HideInInspector]
    public WeaponShot weaponShot;

    private BulletScript[] bulletScript;

    void Start()
    {
        bulletScript = GetComponents<BulletScript>();
        timerLive = timeLive;
    }

    void Update()
    {
        timerLive--;
        if(timerLive < 0)
        {
            destroyBullet();
        }
    }

    public void initBullet(int teamId, Vector3 direction, GameObject weapon, WeaponShot weaponShot)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = direction * speedMove;
        this.teamId = teamId;
        this.direction = direction;
        this.weapon = weapon;
        this.weaponShot = weaponShot;
        bulletScript = GetComponents<BulletScript>();
        for (int x = 0; x < bulletScript.Length; x++)
        {
            bulletScript[x].weapon = weapon;
            bulletScript[x].weaponShot = weaponShot;
            bulletScript[x].bulletInit();
        }
    }

    public void bulletRapture(GameObject entity)
    {
        BulletRapture[] rapture = GetComponents<BulletRapture>();
        for(int x = 0; x < rapture.Length; x++)
        {
            rapture[x].bulletRapture(entity);
        }
    }

    public void destroyBullet()
    {
        BulletRapture[] rapture = GetComponents<BulletRapture>();
        for (int x = 0; x < rapture.Length; x++)
        {
            rapture[x].destroyBullet();
        }
    }

    public void effectBullet()
    {
        ShotEffect[] effect = GetComponents<ShotEffect>();
        for (int x = 0; x < effect.Length; x++)
        {
            effect[x].effect(new Vector3(0, 0));
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Entity")
        {
            EntityController state = collision.gameObject.GetComponent<EntityController>();
            if (!state.isDeath)
            {
                if (state.teamId != teamId)
                {
                    bulletRapture(collision.gameObject);
                    effectBullet();
                    destroyBullet();
                }
            }
        }
        else if(collision.gameObject.layer == 8)
        {
            effectBullet();
            destroyBullet();
        }
    }
}
