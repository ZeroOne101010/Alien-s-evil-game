using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speedMove;
    public float teamId;

    void Start()
    {

    }

    void Update()
    {

    }

    public void initBullet(int teamId, Vector3 direction)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = direction * speedMove;
        this.teamId = teamId;
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
            if (state.teamId != teamId)
            {
                bulletRapture(collision.gameObject);
                effectBullet();
                destroyBullet();
            }
        }
        else if(collision.gameObject.layer == 8)
        {
            effectBullet();
            destroyBullet();
        }
    }
}
