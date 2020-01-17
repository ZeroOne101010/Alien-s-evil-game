using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpread : BulletScript
{

    public GameObject[] spreadGameObject;

    public Vector2 offsetSpawn;

    public int timeSpread;

    public float distanceToShock;

    [HideInInspector]
    public GameObject targetShok;

    [HideInInspector]
    public int countCreatedSpreadInOneSpread = 1;

    [HideInInspector]
    public Vector2 directionSpread;

    [HideInInspector]
    public bool isFirstSpread = true;

    //[HideInInspector]
    public List<GameObject> alreadyShokEntity;

    [HideInInspector]
    public bool canSpread;

    private int timerSpread;

    public override void bulletInit()
    {
        base.bulletInit();
        canSpread = true;
        alreadyShokEntity = new List<GameObject>();
        timerSpread = timeSpread;
        isFirstSpread = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (targetShok != null)
        {
            float distance = Vector2.Distance(transform.position, targetShok.transform.position);
            if (distance < GetComponent<BoxCollider2D>().size.x)
            {
                alreadyShokEntity.Add(targetShok);
                findTarget();
            }
        }
    }

    public void findTarget()
    {
        GameObject[] entity = GameObject.FindGameObjectsWithTag("Entity");
        float maxDistance = 0;
        bool isHave = false;
        for (int x = 0; x < entity.Length; x++)
        {
            float distance = Vector2.Distance(transform.position, entity[x].transform.position);
            EntityController entityController = entity[x].GetComponent<EntityController>();
            if (maxDistance < distance && distance < distanceToShock && entityController.teamId != weapon.GetComponent<WeaponController>().keepedEntity.GetComponent<EntityController>().teamId)
            {
                bool can = true;
                for (int y = 0; y < alreadyShokEntity.Count; y++)
                {
                    if (entity[x] == alreadyShokEntity[y])
                    {
                        can = false;
                        break;
                    }
                }
                if (can)
                {
                    targetShok = entity[x];
                    isHave = true;
                }
            }
        }
        if (!isHave)
        {
            canSpread = false;
        }
    }

    public void spread()
    {
        if (canSpread)
        {
            if (targetShok == null)
            {
                findTarget();
            }
        }

        if (canSpread)
        {
            if (isFirstSpread)
            {
                GameObject entity = weapon.GetComponent<WeaponController>().keepedEntity;
                EntityMove entityMove = entity.GetComponent<EntityMove>();

                bool isRight = false;

                if (entityMove != null)
                {
                    isRight = entityMove.isRight;
                }
                else
                {
                    isRight = entity.transform.rotation.y >= 0;
                }

                float directionK = isRight ? 1 : -1;
                directionSpread = new Vector2(directionK, 0);
            }

            int idPrifab = Random.Range(0, spreadGameObject.Length);

            Vector2 direction = (targetShok.transform.position - transform.position).normalized;

            Vector2 spawnPos = (Vector2)(transform.position) + (offsetSpawn * direction);
            Quaternion randQu = new Quaternion(0, 0, Random.Range(-60, 60), 0);

            GameObject spreadObject = Instantiate(spreadGameObject[idPrifab], spawnPos, randQu);
            SpreadOfLightning spreadOfLighting = spreadObject.GetComponent<SpreadOfLightning>();
            spreadOfLighting.isFirstSpread = false;
            spreadOfLighting.directionSpread = directionSpread;
            countCreatedSpreadInOneSpread--;
        }
    }


    public override void bulletUpdate()
    {
        base.bulletUpdate();
        timerSpread--;
        if (timerSpread < 0)
        {
            if (countCreatedSpreadInOneSpread > 0)
            {
                if (isFirstSpread)
                {
                    spread();
                    isFirstSpread = false;
                }
                else
                {
                    spread();
                }
                timerSpread = timeSpread;
            }
        }
    }
}

