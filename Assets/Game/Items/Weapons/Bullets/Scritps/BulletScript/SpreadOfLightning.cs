//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpreadOfLightning : BulletScript
//{

//    public GameObject[] spreadGameObject;

//    public Vector2 offsetSpawn;

//    public int timeSpread;

//    public float distanceToShock;

//    [HideInInspector]
//    public GameObject targetShok;

//    [HideInInspector]
//    public int countCreatedSpreadInOneSpread = 1;

//    [HideInInspector]
//    public Vector2 directionSpread;

//    [HideInInspector]
//    public bool isFirstSpread = true;

//    //[HideInInspector]
//    public List<GameObject> alreadyShokEntity;

//    [HideInInspector]
//    public bool canSpread;

//    private int timerSpread;

//    public override void bulletInit()
//    {
//        base.bulletInit();
//        canSpread = true;
//        alreadyShokEntity = new List<GameObject>();
//        timerSpread = timeSpread;
//        isFirstSpread = true;
//        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

//        if (targetShok != null)
//        {
//            float distance = Vector2.Distance(transform.position, targetShok.transform.position);
//            if (distance < GetComponent<BoxCollider2D>().size.x)
//            {
//                alreadyShokEntity.Add(targetShok);
//                findTarget();
//            }
//        }
//    }

//    public void findTarget()
//    {
//        GameObject[] entity = GameObject.FindGameObjectsWithTag("Entity");
//        float maxDistance = 0;
//        bool isHave = false;
//        for (int x = 0; x < entity.Length; x++)
//        {
//            float distance = Vector2.Distance(transform.position, entity[x].transform.position);
//            EntityController entityController = entity[x].GetComponent<EntityController>();
//            if (maxDistance < distance && distance < distanceToShock && entityController.teamId != weapon.GetComponent<WeaponController>().keepedEntity.GetComponent<EntityController>().teamId)
//            {
//                bool can = true;
//                for (int y = 0; y < alreadyShokEntity.Count; y++)
//                {
//                    if (entity[x] == alreadyShokEntity[y])
//                    {
//                        can = false;
//                        break;
//                    }
//                }
//                if (can)
//                {
//                    targetShok = entity[x];
//                    isHave = true;
//                }
//            }
//        }
//        if (!isHave)
//        {
//            canSpread = false;
//        }
//    }

//    public void spread()
//    {
//        if (canSpread)
//        {
//            if (targetShok == null)
//            {
//                findTarget();
//            }
//        }

//        if (canSpread)
//        {
//            if (isFirstSpread)
//            {
//                GameObject entity = weapon.GetComponent<WeaponController>().keepedEntity;
//                EntityMove entityMove = entity.GetComponent<EntityMove>();

//                bool isRight = false;

//                if (entityMove != null)
//                {
//                    isRight = entityMove.isRight;
//                }
//                else
//                {
//                    isRight = entity.transform.rotation.y >= 0;
//                }

//                float directionK = isRight ? 1 : -1;
//                directionSpread = new Vector2(directionK, 0);
//            }

//            int idPrifab = Random.Range(0, spreadGameObject.Length);

//            Vector2 direction = (targetShok.transform.position - transform.position).normalized;

//            Vector2 spawnPos = (Vector2)(transform.position) + (new Vector2(Random.Range(offsetSpawn.x / 2, offsetSpawn.x), Random.Range(offsetSpawn.y / 2, offsetSpawn.y)) * direction);
//            Quaternion randQu = new Quaternion(0, 0, Random.Range(-60, 60), 0);

//            GameObject spreadObject = Instantiate(spreadGameObject[idPrifab], spawnPos, randQu);
//            SpreadOfLightning spreadOfLighting = spreadObject.GetComponent<SpreadOfLightning>();
//            spreadOfLighting.isFirstSpread = false;
//            spreadOfLighting.directionSpread = directionSpread;
//            countCreatedSpreadInOneSpread--;
//        }
//    }


//    public override void bulletUpdate()
//    {
//        base.bulletUpdate();
//        timerSpread--;
//        if (timerSpread < 0)
//        {
//            if (countCreatedSpreadInOneSpread > 0)
//            {
//                if (isFirstSpread)
//                {
//                    spread();
//                    isFirstSpread = false;
//                }
//                else
//                {
//                    spread();
//                }
//                timerSpread = timeSpread;
//            }
//        }
//    }

//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadOfLightning : BulletScript
{

    public GameObject[] spreadGameObject;

    public Vector2 offsetSpawn;

    public int timeSpread;


    public int maxCountSpread;
    public int scatterSpreadCount;

    [HideInInspector]
    public int countCreatedSpreadInOneSpread = 1;

    [HideInInspector]
    public Vector2 directionSpread;

    [HideInInspector]
    public int spreadId;

    [HideInInspector]
    public bool isFirstSpread = true;

    private int timerSpread;

    public override void bulletInit()
    {
        base.bulletStart();
        timerSpread = timeSpread;
        isFirstSpread = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void spread()
    {
        if (spreadId > 0)
        {
            if (isFirstSpread)
            {
                GameObject entity = weapon.GetComponent<WeaponController>().keepedEntity;
                EntityMoveController entityMove = entity.GetComponent<EntityMoveController>();

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

            Vector2 spawnPos = (Vector2)(transform.position) + new Vector2(offsetSpawn.x * directionSpread.x, Random.Range(-offsetSpawn.y, offsetSpawn.y));
            Quaternion randQu = new Quaternion(0, 0, Random.Range(-60, 60), 0);

            GameObject spreadObject = Instantiate(spreadGameObject[idPrifab], spawnPos, randQu);
            SpreadOfLightning spreadOfLighting = spreadObject.GetComponent<SpreadOfLightning>();
            spreadOfLighting.isFirstSpread = false;
            spreadOfLighting.spreadId = spreadId - 1;
            spreadOfLighting.directionSpread = directionSpread;
            countCreatedSpreadInOneSpread--;
        }
    }

    public void startSpread()
    {
        spreadId = Random.Range(maxCountSpread - scatterSpreadCount, maxCountSpread + scatterSpreadCount);
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
                    startSpread();
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





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpreadOfLightning : BulletScript
//{

//    public GameObject[] spreadGameObject;

//    public Vector2 offsetSpawn;

//    public int maxCountSpread;
//    public int ScatterSpread;

//    public int timeToSpreadLighting;

//    [HideInInspector]
//    public int spreadId;

//    [HideInInspector]
//    public Vector2 directionSpread;


//    [HideInInspector]
//    public bool isFirstLighting = true;

//    private int timerToSpreadLighting;
//    private StreamBullets streamBullet;

//    public override void bulletStart()
//    {
//        base.bulletStart();
//        isFirstLighting = true;
//        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
//        timerToSpreadLighting = timeToSpreadLighting;
//    }


//    public void startSpread()
//    {
//        if (isFirstLighting)
//        {
//            spreadId = Random.Range(maxCountSpread - ScatterSpread, maxCountSpread);
//            if (isFirstLighting)
//            {
//                WeaponController weaponController = weapon.GetComponent<WeaponController>();
//                EntityController entity = weaponController.keepedEntity.GetComponent<EntityController>();
//                EntityMove entityMove = entity.GetComponent<EntityMove>();
//                float direction = 0;

//                if (entityMove != null)
//                {
//                    direction = entityMove.isRight ? 1 : 0;
//                }

//                directionSpread = new Vector2(direction, 0);
//            }
//            isFirstLighting = false;
//        }
//    }

//    public void spreadLighting()
//    {
//        if (spreadId > 0)
//        {
//            int idSpreadGameObject = Random.Range(0, spreadGameObject.Length);

//            Quaternion randQu = new Quaternion(0, 0, Random.Range(110, 250), 0);

//            GameObject bullet = Instantiate(spreadGameObject[idSpreadGameObject], new Vector2(offsetSpawn.x * directionSpread.x, Random.Range(-offsetSpawn.y, offsetSpawn.y)), randQu);

//            SpreadOfLightning spreadOfLighting = bullet.GetComponent<SpreadOfLightning>();
//            if (spreadOfLighting != null)
//            {
//                spreadOfLighting.isFirstLighting = false;
//                spreadOfLighting.directionSpread = directionSpread;
//                spreadOfLighting.spreadId = spreadId - 1;
//                spreadOfLighting.startSpread();
//            }
//        }
//    }

//    public override void bulletUpdate()
//    {
//        startSpread();
//        timerToSpreadLighting--;
//        if (timerToSpreadLighting < 0) timerToSpreadLighting = 0;
//        if (timerToSpreadLighting == 0)
//        {
//            spreadLighting();
//            timerToSpreadLighting = timeToSpreadLighting;
//        }

//        base.bulletUpdate();
//    }

//}

